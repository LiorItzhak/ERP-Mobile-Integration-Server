using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using CsvHelper.Configuration;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using LogicLib.Utils;
using MoreLinq;

namespace LogicLib.Services.Impl
{
    public class EmployeeTimeClockService : IEmployeeTimeClockService
    {
        private readonly IDalService _dalService;

        public EmployeeTimeClockService(IDalService dalService)
        {
            _dalService = dalService;
        }


        public async Task<EmployeeTimeClock> CheckInAsync(CheckInRequest checkInRequest,
            CancellationToken cancellationToken)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            //ensure that the employee is exist and active
            var emp = await transaction.Employees.SingleOrDefaultAsync(x => x.Sn == checkInRequest.EmployeeSn);
            if (emp == null)
                throw new IllegalArgumentException($"Employee {checkInRequest.EmployeeSn} doesn't exist");
            if (!emp.IsActive)
                throw new InvalidStateException($"Employee {checkInRequest.EmployeeSn} is not active");

            //ensure that the applicant isn't already checked in 
            var isCheckedOut = await IsEmployeeCheckedOut(transaction, checkInRequest.EmployeeSn);
            if (!isCheckedOut)
                throw new InvalidStateException($"Employee {checkInRequest.EmployeeSn} already checked in");

            var employeeTimeClock = new EmployeeTimeClock
            {
                EmployeeSn = checkInRequest.EmployeeSn,
                CheckIn = DateTimeOffset.Now,
                CheckInLocation = checkInRequest.CheckInLocation,
                Properties = checkInRequest.Properties
            };

            employeeTimeClock = await transaction.EmployeeTimeClocks.AddAsync(employeeTimeClock);
            cancellationToken.ThrowIfCancellationRequested();
            await transaction.CompleteAsync(cancellationToken);
            return employeeTimeClock;
        }

        public async Task<EmployeeTimeClock> CheckOutAsync(CheckOutRequest checkOutRequest,
            CancellationToken cancellationToken)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            //checks if the applicant is already checked in 
            var isCheckedOut = await IsEmployeeCheckedOut(transaction, checkOutRequest.EmployeeSn);
            if (isCheckedOut)
                throw new InvalidStateException($"Employee {checkOutRequest.EmployeeSn} isn't checked in");
            var timeClock = await GetEmployeeLastCheckIn(transaction, checkOutRequest.EmployeeSn);
            timeClock.CheckOut = DateTimeOffset.Now;
            timeClock.CheckOutLocation = checkOutRequest.CheckOutLocation;
            timeClock.Comments = checkOutRequest.Comments;
            if (checkOutRequest.Properties != null) timeClock.Properties = checkOutRequest.Properties;
            timeClock = await transaction.EmployeeTimeClocks.UpdateAsync(timeClock);
            cancellationToken.ThrowIfCancellationRequested();
            await transaction.CompleteAsync(cancellationToken);
            return timeClock;
        }

        public async Task<byte[]> GenerateCsv()
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var records = await transaction.EmployeeTimeClocks
                .GetAllAsync(PageRequest.Of(0, int.MaxValue,
                    Sort<EmployeeTimeClock>.By(x => x.CheckIn, OrderType.Desc)));

            //create csv file from the collection
            return await records.ToCsvAsync();
        }


        public async Task<IEnumerable<EmployeeTimeClock>> GeTimeClocks(DateTimeOffset fromDate, DateTimeOffset toDate,
            int page, int size, int? employeeSn = null, bool considerTimeOfDay = false)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.EmployeeTimeClocks
                .FindAllAsync(x =>
                        (considerTimeOfDay && x.CheckIn >= fromDate && x.CheckIn <= toDate ||
                         !considerTimeOfDay && x.CheckIn.Date >= fromDate.Date && x.CheckIn.Date <= toDate.Date)
                        && (employeeSn == null || x.EmployeeSn == employeeSn),
                    PageRequest.Of(page, size, Sort<EmployeeTimeClock>.By(x => x.CheckIn, OrderType.Asc)));
        }

        public async Task<IEnumerable<EmployeeTimeClockShift>> TestGeTimeClocks(DateTimeOffset fromDate,
            DateTimeOffset toDate,
            int page, int size, int? employeeSn = null, bool considerTimeOfDay = false)
        {
            var empTimeClocks = await GeTimeClocks(fromDate, toDate, page, size, employeeSn, considerTimeOfDay);
            // Partition by employee
            return empTimeClocks.GroupBy(x => x.EmployeeSn)
                .SelectMany(g =>
                {
                    // Calculate the difference between 2 successive check in -> check out as BreakDuration
                    var list = g.WindowRight(2).Select(x => new
                    {
                        Element = x.Last(),
                        BreakDuration = x.Count == 2 ? x.Max(t => t.CheckIn) - x.Min(t => t.CheckOut) : null,
                        CheckInsDaysDiff = (x.Last().CheckIn.Date - x.First().CheckIn.Date).TotalDays
                    });
                    
                    // if BreakDuration is higher then threshold and mark it as new shift
                    // if the different between 2 successive check-ins is higher 0 days mark it as new shift
                    var list2 = list.Select(x => new
                    {
                        x.Element,
                        x.BreakDuration ,
                        Shift = (x.BreakDuration.HasValue == false || x.BreakDuration > new TimeSpan(6, 0, 0)) ? 1 :
                            x.CheckInsDaysDiff > 0 ? 1 : 0
                    });

                    // Set a unique key foreach shift
                    var list3 = list2.CumulativeSum((x1, x2) => new
                    {
                        x2.Element,
                        x2.BreakDuration,
                        Shift = x2.Shift + x1.Shift // unique shift key
                    });

                    // Aggregate brakes durations and comments
                    var list4 = list3.GroupBy(x => x.Shift,
                        (k, shift) =>
                        {
                            var shiftE = shift.ToList();
                            var employeeTimeClocks = shiftE.Select(x=>x.Element).ToList();
                            return new EmployeeTimeClockShift
                            {
                                Key = employeeTimeClocks.First().Key,
                                EmployeeSn = employeeTimeClocks.First().EmployeeSn,
                                CheckIn = employeeTimeClocks.OrderBy(x => x.CheckIn).First().CheckIn,
                                CheckOut = employeeTimeClocks.OrderBy(x => x.CheckIn).Last().CheckOut,
                                Comments = employeeTimeClocks.Where(x => string.IsNullOrWhiteSpace(x.Comments) == false)
                                    .Aggregate("", (c1, c2) => $"{c1} | {c2.Comments}"),
                                CheckInLocation = employeeTimeClocks.OrderBy(x => x.CheckIn).First().CheckInLocation,
                                CheckOutLocation = employeeTimeClocks.OrderBy(x => x.CheckIn).Last().CheckOutLocation,
                                BreakDuration = shiftE.Select(x=>x.BreakDuration)
                                    .Skip(1)// skip first shift entry
                                    .Where(x=>x.HasValue)
                                    .Sum((x1,x2)=>x1+x2)??TimeSpan.Zero
                            };
                        });
                    
                    return list4;
                });
        }

        public async Task<byte[]> GenerateCsvBytes(DateTimeOffset fromDate, DateTimeOffset toDate,
            int? employeeSn = null, bool considerTimeOfDay = false)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var empTimeClocks =
                await TestGeTimeClocks(fromDate, toDate, 0, int.MaxValue, employeeSn, considerTimeOfDay);
            //create csv file from the collection
            var employeeTimeClocks = empTimeClocks as EmployeeTimeClock[] ?? empTimeClocks.ToArray();
            var empCodes = employeeTimeClocks.Select(x => x.EmployeeSn).Distinct();
            var employees = await transaction.Employees
                .FindAllAsync(x => empCodes.Contains(x.Sn), PageRequest.Of(0, int.MaxValue));

            var records = employeeTimeClocks
                .Join(employees,
                    tc => tc.EmployeeSn,
                    emp => emp.Sn,
                    (tc, emp) => new EmployeeTimeClockMap(emp, tc));

            return await records.ToCsvAsync(typeof(EmployeeTimeClockMap));
        }


        private static async Task<bool> IsEmployeeCheckedOut(IUnitOfWork transaction, int employeeSn)
        {
            var lastCheckIn = await GetEmployeeLastCheckIn(transaction, employeeSn);
            return lastCheckIn == null || lastCheckIn.CheckOut != null;
        }

        private static async Task<EmployeeTimeClock> GetEmployeeLastCheckIn(IUnitOfWork transaction, int employeeSn)
        {
            var lastCheckIn = await transaction.EmployeeTimeClocks
                .FirstOrDefaultAsync(x => x.EmployeeSn == employeeSn,
                    Sort<EmployeeTimeClock>.By(x => x.CheckIn, OrderType.Desc));
            return lastCheckIn;
        }

        public async Task<EmployeeTimeClock> GetLastTimeClock(int employeeSn)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var lastCheckIn = await GetEmployeeLastCheckIn(transaction, employeeSn);
            return lastCheckIn;
        }
    }
}


public sealed class EmployeeTimeClockShift : EmployeeTimeClock
{ 
    public TimeSpan BreakDuration { get; set; }
}

sealed class EmployeeTimeClockMap : ClassMap<EmployeeTimeClockMap>
{
    // ReSharper disable  MemberCanBePrivate.Global
    public long? Key { get; set; }
    public int EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string CheckInDayInWeek { get; set; }

    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset? CheckOut { get; set; }
    public double? TotalDuration { get; set; }

    public double? BreakDuration { get; set; }
    public double? Duration { get; set; }

    public string Comments { get; set; }

    public string CheckInLocation { get; set; }
    public string CheckOutLocation { get; set; }


    public EmployeeTimeClockMap(EmployeeEntity employee, EmployeeTimeClock employeeTimeClock) : this()
    {
        Key = employeeTimeClock.Key;
        EmployeeCode = employeeTimeClock.EmployeeSn;
        CheckInDayInWeek = DateTimeFormatInfo.CurrentInfo?.GetDayName(employeeTimeClock.CheckIn.DayOfWeek);
        CheckIn = employeeTimeClock.CheckIn;
        CheckOut = employeeTimeClock.CheckOut;
        TotalDuration = employeeTimeClock.CheckOut.HasValue
            ? (employeeTimeClock.CheckOut - employeeTimeClock.CheckIn).Value.TotalMinutes / 60
            : (double?) null;
        if (employeeTimeClock is EmployeeTimeClockShift shift)
        {
            BreakDuration = shift.BreakDuration.TotalMinutes / 60;
            Duration = TotalDuration - BreakDuration;
        }

        Comments = employeeTimeClock.Comments;
        EmployeeName = $"{employee.FirstName} {employee.LastName}";
        CheckInLocation = employeeTimeClock.CheckInLocation != null
            ? $"{employeeTimeClock.CheckInLocation.Address}, ({employeeTimeClock.CheckInLocation.Latitude},{employeeTimeClock.CheckInLocation.Longitude})"
            : null;
        CheckOutLocation = employeeTimeClock.CheckOutLocation != null
            ? $"{employeeTimeClock.CheckOutLocation.Address}, ({employeeTimeClock.CheckOutLocation.Latitude},{employeeTimeClock.CheckOutLocation.Longitude})"
            : null;
    }


    public EmployeeTimeClockMap()
    {
        Map(m => m.Key).Name("Key");
        Map(m => m.EmployeeCode).Name("Employee Code");
        Map(m => m.EmployeeName).Name("Employee Name");
        Map(m => m.CheckInDayInWeek).Name("CheckIn Day");
        Map(m => m.CheckIn).Name("CheckIn");
        Map(m => m.CheckOut).Name("CheckOut");
        Map(m => m.TotalDuration).Name("Total Duration(hours)");
        Map(m => m.BreakDuration).Name("Break Duration(hours)");
        Map(m => m.Duration).Name("Duration(hours)");
        Map(m => m.Comments).Name("Comments");
        Map(m => m.CheckInLocation).Name("CheckIn Location");
        Map(m => m.CheckOutLocation).Name("CheckOut Location");
    }
}