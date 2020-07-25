using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities.BusinessPartners;
using Microsoft.Extensions.Logging;

namespace LogicLib
{
    public class ActionAttribute : Attribute
    {
        public string Type { get; }

        public ActionAttribute(string type)
        {
            Type = type;
        }
    }

    public interface IActionService
    {
        Task<object> ExecuteAction(Dictionary<string, string> actionProps,CancellationToken cancellationToken = default);
    }

    [Action("Test")]
    public class TestAction : IActionService
    {
        private readonly ILogger<TestAction> _logger;

        public TestAction(ILogger<TestAction> logger)
        {
            _logger = logger;
        }

        public async Task TestLog(string log)
        {
            _logger.LogInformation(log);
        }


        public async Task<object> ExecuteAction(Dictionary<string, string> actionProps, CancellationToken cancellationToken = default)
        {
            var log = actionProps["Log"];

            _logger.LogInformation(log);
            return new Activity
            {
                Code = 555
            };
            
        }
    }
}