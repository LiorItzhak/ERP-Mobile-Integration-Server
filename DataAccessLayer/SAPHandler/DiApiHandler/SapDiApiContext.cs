using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using DataAccessLayer.Entities;
using SAPbobsCOM;
using DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets;
using System.Reflection;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using CrossLayersUtils.Utils.Reflections;
using DataAccessLayer.Entities.Documents;
using System.Threading;
using System.Runtime.Serialization;
using CrossLayersUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace DataAccessLayer.SAPHandler.DiApiHandler
{
    public class SapDiApiContext : IDisposable, ISaveable
    {
        private readonly CompanyContext _companyContext;
        private readonly Company _company;

        public CompanyContext GetCompany()
        {
            return _companyContext;
        }

        public SapDiApiContext(string connectionString,ILogger<SapDiApiContext> logger)
        {
            _company = new Company();
            _companyContext = new CompanyContext(connectionString, _company, logger);
            this.InjectInstanceOf(typeof(DiSet<,>), _companyContext);
        }

        ~SapDiApiContext() => Dispose(); //for unlock DI-API via GC - normally call dispose or use using manually!  

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            if (_company != null && _company.Connected)
            {
                if (_company.InTransaction)
                {
                    _company.EndTransaction(BoWfTransOpt.wf_RollBack);
                    Debug.WriteLine("Sap Di-API end transaction : Rollback");
                }

                _company.Disconnect();
                Debug.WriteLine("Sap Di-API disconnected ");
            }

            FreeResources();
            IsDisposed = true;
        }

        public int SaveChanges()
        {
            var x = 0;
            if (_company != null && _company.Connected && _company.InTransaction)
            {
                _company.EndTransaction(BoWfTransOpt.wf_Commit);
                Debug.WriteLine("Sap Di-API end transaction : Committed");
                x = _companyContext.GetAffectedObjectCounter();
            }

            FreeResources();
            return x;
        }


        private void FreeResources()
        {
            _companyContext.Dispose();
        }

        public BusinessPartnerDiSet BusinessPartners { get; private set; }
        public DocumentDiSet<QuotationEntity> Quotations { get; private set; }
        public DocumentDiSet<OrderEntity> Orders { get; private set; }
        public DocumentDiSet<DeliveryNoteEntity> DeliveryNotes { get; private set; }
        public DocumentDiSet<InvoiceEntity> Invoices { get; private set; }
        public DocumentDiSet<CreditNoteEntity> CreditNotes { get; private set; }
        public DocumentDiSet<DownPaymentRequest> DownPaymentRequests { get; private set; }
        public ActivityDiSet Activities { get; private set; }
        public AttachmentDiSet Attachments { get; private set; }


        public class CompanyContext : IDisposable
        {
            private int _numOfAffectedObject = 0;
            private readonly Company _company;
            private readonly string _connectionString;
            private static readonly ObjectIDGenerator IdGenerator = new ObjectIDGenerator();
            private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
            private static long? _lockingObjId;
            private readonly long _objId;
            private readonly ILogger<SapDiApiContext> _logger;

            public CompanyContext(string connectionString, Company company, ILogger<SapDiApiContext> logger)
            {
                _logger = logger;
                _objId = IdGenerator.GetId(this, out _);
                _company = company;
                _connectionString = connectionString;
            }

            public Company ConnectCompany()
            {
                ConnectAndStartTransaction();
                return _company;
            }


            private void Connect(ICompany company)
            {
                if (company != null && company.Connected)
                    return;

                if (company == null)
                {
                    throw new Exception("SapDiApi company is null - cant connect");
                }

                var connectionValues = new Dictionary<string, string>();
                try
                {
                    _connectionString.Split(";").ToList()
                        .ForEach(str =>
                        {
                            var s = str.Split("=");
                            if (s.Length == 2)
                                connectionValues.Add(s[0].ToUpper(), s[1]);
                        });
                    company.CompanyDB = connectionValues["COMPANYDB"];
                    company.Server = connectionValues["SERVER"];
                    ;
                    company.LicenseServer = connectionValues["LICENSESERVER"];
                    company.SLDServer = connectionValues["SLDSERVER"];
                    company.DbUserName = connectionValues["DBUSERNAME"];
                    company.DbPassword = connectionValues["DBPASSWORD"];
                    company.UserName = connectionValues["USERNAME"];
                    company.Password = connectionValues["PASSWORD"];
                    company.DbServerType = connectionValues["DBSERVERTYPE"].ToUpper() switch
                    {
                        "MSSQL2012" => BoDataServerTypes.dst_MSSQL2012,
                        "MSSQL2014" => BoDataServerTypes.dst_MSSQL2014,
                        "MSSQL2016" => BoDataServerTypes.dst_MSSQL2016,
                        "MSSQL" => BoDataServerTypes.dst_MSSQL,
                        _ => company.DbServerType
                    };
                    company.UseTrusted = connectionValues["USETRUSTED"] == "TRUE";
                }
                catch
                {
                    //don't expose the connection string through an exception
                    throw new Exception("connection string error!");
                }

                var ret = company.Connect();
                var errMsg = company.GetLastErrorDescription();
                var errNo = company.GetLastErrorCode();
                if (errNo != 0)
                {
                    var msg = $"DI-API Connect error: ErrorCode {errNo} = {errMsg}";
                    throw new Exception(msg);
                }
            }


            private void FreeResources()
            {
                if (_lockingObjId != _objId) return;
                _lockingObjId = null;
                Semaphore.Release();
            }

            private void ConnectAndStartTransaction()
            {
                if (_lockingObjId != _objId)
                    Semaphore.Wait();
                _lockingObjId = _objId;

                if (_company == null || !_company.Connected)
                {
                    _logger.LogDebug("Connecting to SAP DI-API");
                    Connect(_company);
                    _logger.LogDebug("SAP DI-API Connected");
                }

                if (_company == null || _company.InTransaction) return;
                _company.StartTransaction();
                _numOfAffectedObject = 0;
                _logger.LogDebug("Sap Di-API start transaction");
            }

            public void IncrementAffectedObjectCounter()
            {
                _numOfAffectedObject++;
            }

            public int GetAffectedObjectCounter()
            {
                return _numOfAffectedObject;
            }

            public void Dispose()
            {
                FreeResources();
            }

            ~CompanyContext() => Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            //sap DI_API don't support async saves
            //implemented it only to support the interface
            return await Task.Run(SaveChanges);
        }
    }
}