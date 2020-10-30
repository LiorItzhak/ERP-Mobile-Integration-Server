using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LogicLib.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoreLinq.Extensions;
using Web_Api.Controllers.Docs.Utils;
using Web_Api.DTOs;
using Web_Api.DTOs.Documents;

namespace Web_Api.Controllers
{
    public class OferInterceptorAttribute : TypeFilterAttribute
    {
        public OferInterceptorAttribute() : base(typeof(OferFilterImpl))
        {
        }

        private class OferFilterImpl : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
                var empId = (context.Controller as ControllerBase)?.User.Claims 
                    .SingleOrDefault(x => x.Type == AuthenticationResult.EmployeeSnClaimTag)?.Value;
                if(empId != "1")
                    return;
                // perform some business logic work
                var result = (ObjectResult) context.Result;
                if (result == null)
                    return;

                if (result.Value.GetType().GetInterfaces().Any(
                    i => i.IsGenericType &&
                         i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                {
                    result.Value = (result.Value as IEnumerable)!.Cast<object>().ToArray();
                }
                    
                if (result.Value.GetType().IsArray)
                {
                    foreach (var o in (Array) result.Value)
                    {
                        Intercept(o);
                    }
                }
                else
                {
                    Intercept(result.Value);
                }
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                var empId = (context.Controller as ControllerBase)?.User.Claims 
                    .SingleOrDefault(x => x.Type == AuthenticationResult.EmployeeSnClaimTag)?.Value;
                if(empId != "1")
                    return;
                
               
                if (context.HttpContext.Request.Query.ContainsKey("modifiedAfter") || context.HttpContext.Request.Query.ContainsKey("updatedAfter"))
                {
               
                    var l = context.HttpContext.Request.Query.ToList().ToDictionary();
                    var dateString = l.GetValueOrDefault("updatedAfter", l.GetValueOrDefault("modifiedAfter", ""));
                    var modifiedDate = DateTime.Parse(dateString);
                    if(modifiedDate < new DateTime(2020,10,28))
                    {
                        l.Remove("updatedAfter");
                        l.Remove("modifiedAfter");
                        context.ActionArguments["modifiedAfter"] = null;
                        context.ActionArguments["updatedAfter"] = null;
                        context.HttpContext.Request.Query = new QueryCollection(l);
                    }
                }
                if (context.HttpContext.Request.Method.ToUpper() != "GET")
                {
                    throw new NotSupportedException("Interceptor");
                }
            }

            private static object Intercept(object o)
            {
                
                if (o is BusinessPartnerDto x)
                {
                    if (x.ShippingAddress != null)
                    {
                        x.ShippingAddress.City = "CITY";
                        x.ShippingAddress.NumAtStreet = "NumAtStreet";
                        x.ShippingAddress.Street = "Street";
                        x.ShippingAddress.Apartment = "Apartment";
                        x.ShippingAddress.Block = "Block";

                    }
                    if (x.BillingAddress != null)
                    {
                        x.BillingAddress.City = "CITY";
                        x.BillingAddress.NumAtStreet = "NumAtStreet";
                        x.BillingAddress.Street = "Street";
                        x.BillingAddress.Apartment = "Apartment";
                        x.BillingAddress.Block = "Block";
                    }
                  
                    x.GeoLocation = null;
                    x.PartnerType = BusinessPartnerDto.PartnerTypes.Customer;
                    x.Phone2 = null;
                    x.Phone1 = "000";
                    x.AttachmentsCode = null;
                    x.IsActive = false;
                    x.Name = "NAME";
                    x.Comments = "";
                    x.Balance = 0;
                    x.Cellular = null;
                    x.Email = null;
                    x.Fax = null;
                }
                else if(o is EmployeeDto e)
                {
                    e.FirstName = "OFER";
                    e.LastName = "OFER";
                    e.Email = "OFER";
                    e.JobTitle = "OFER";
                    e.PicPath = null;
                    e.HomePhone = "";
                    e.MiddleName = "";
                    e.WorkCellular = "";
                }
                else if(o is DocumentDto doc)
                {
                    doc.Comments = "OFER";
                    doc.Items = null;
                    doc.IsClosed = true;
                    doc.CustomerName = "OFER";
                    doc.CustomerAddress = "OFER";
                    doc.DocTotal = 0;
                    doc.SalesmanSn = -1;
                    doc.ToPay = 0;
                    doc.CustomerSn = "00";
                    doc.GrossProfit = 0;
                    doc.TotalDiscountAndRounding = 0;
                } else if (o is ActivityDto a)
                {
                    a.Notes = "";
                    a.IsClosed = true;
                    a.Details = "";
                    a.IsActive = false;
                    a.BeginDateTime = "2000-03-04T08:00:00.0000000";
                    a.HandleByEmployeeCode = 9;
                }
                else if (o is DocumentsSummeryDto ds )
                {
                    ds.TotalToPay = 0;
                    ds.TotalVat = 0;
                    ds.Type = DocumentsSummeryDto.DocType.CreditNote;
                }
     

                return o;
            }
            
        }
    }
}