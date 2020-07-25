using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LogicLib.Services;
using LogicLib.Services.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using IdentityUser = DataAccessLayer.Entities.Authentication.IdentityUser;

namespace Web_Api.StartupTasks
{
    public class AddUsersStartupTask : IStartupTask
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmployeesService _employeesService;
        private readonly ILogger<AddUsersStartupTask> _logger;

        public AddUsersStartupTask(UserManager<IdentityUser> userManager, 
            IEmployeesService employeesService,
            ILogger<AddUsersStartupTask> logger)
        {
            _employeesService = employeesService;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var users = await _userManager.Users.Select(x=>x.UserName)
                    .ToListAsync(cancellationToken);
                 (await _employeesService.GetEmployeesPageAsync(0, int.MaxValue))
                    .Where(x => x.IsActive  && !users.Contains(x.Sn.ToString())) 
                    .ToList().ForEach(employee =>
                    {
                        var user = new IdentityUser
                        {
                            Role = IdentityUser.UserRole.Standard,
                            Email = employee.Email,
                            EmpId = employee.Sn,
                            UserName = employee.Sn.ToString()
                        };
                        const string password = "1234";//TODO
                        try
                        {
                             _userManager.CreateAsync(user, password).Wait(cancellationToken);
                             _logger.LogDebug($"User Added in startup:${user.Email} with empId={user.EmpId},role= {user.Role}");
                        }
                        catch (Exception error)
                        {
                            _logger.LogError($"Failed to create an user({user.Email}) in startup, error:{error.Message}");
                        }
                    });
            }
            catch (Exception error)
            {
                _logger.LogError($"Failed to create users in startup, error:{error.Message}");
            }
        }
    }
}