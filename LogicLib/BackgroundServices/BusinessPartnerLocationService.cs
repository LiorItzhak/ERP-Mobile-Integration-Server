using DataAccessLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Repositories;
using LogicLib.Services;

namespace LogicLib.BackgroundServices
{
    //Check service
    public class BusinessPartnerLocationBackgroundService : IBackgroundService
    {
        private readonly IGeocoderService _geocoderService;
        private readonly IDalService _dalService;
        private readonly ILogger<BusinessPartnerLocationBackgroundService> _logger;


        public BusinessPartnerLocationBackgroundService(IDalService dalService, IGeocoderService geocoderService,
            ILogger<BusinessPartnerLocationBackgroundService> logger)
        {
            _logger = logger;
            _dalService = dalService;
            _geocoderService = geocoderService;
        }


        public async Task UpdateBusinessPartnersGeoLocationAsync(CancellationToken cancellationToken)
        {
            var callCounter = 0;
            var notRequireCounter = 0;

            //get updated customer
            using var transaction = _dalService.CreateUnitOfWork();

            var partnersWithAddress = (await transaction.BusinessPartners.FindAllAsync(
                x => x.IsActive == true,
                PageRequest.Of(0, int.MaxValue))).Select(x => new
            {
                Address = x.BillingAddress ?? x.ShippingAddress,
                Info = x
            }).Where(x => !string.IsNullOrEmpty(x.Address?.City));

            var updatedCustomers = new List<BusinessPartner>(); // logging only

            foreach (var partner in partnersWithAddress)
            {
                var geocoderAddressStr =
                    $"{partner.Address.City}, {partner.Address.Street} {partner.Address.NumAtStreet} ,{partner.Address.Country}";

                if (partner.Info.GeoLocation?.Address == null /*address never evaluated*/ ||
                    !geocoderAddressStr.StartsWith(partner.Info.GeoLocation.Address) /*address changed*/)
                {
                    try
                    {
                        _logger.LogDebug(
                            $"Address {geocoderAddressStr} is been evaluating for customer :{partner.Info.Key}");
                        callCounter++; // logging only
                        var geoLocation = _geocoderService
                            .GetGeoLocationFromAddress(geocoderAddressStr).Result;
                        if (geoLocation != null)
                        {
                            partner.Info.GeoLocation = new SapGeoLocation
                            {
                                Address = geocoderAddressStr,
                                Latitude = geoLocation.Latitude,
                                Longitude = geoLocation.Longitude
                            };
                        }
                        else
                        {
                            _logger.LogDebug(
                                $"Address {geocoderAddressStr} has been evaluated for customer :{partner.Info.Key} with NULL location!!!");
                            partner.Info.GeoLocation = new SapGeoLocation
                            {
                                Address = geocoderAddressStr
                            };
                        }
                    }
                    catch (Exception error)
                    {
                        _logger.LogWarning($"goelocation {geocoderAddressStr} error :{error.Message}");
                        continue; //unsuccessful geocoder call, try next business partner
                    }

                    var customerToUpdate = new BusinessPartner
                    {
                        Key = partner.Info.Key,
                        GeoLocation = partner.Info.GeoLocation
                    };
                    using var updateUow = _dalService.CreateUnitOfWork();
                    await updateUow.BusinessPartners.UpdateAsync(customerToUpdate);
                    await updateUow.CompleteAsync(cancellationToken);
                    _logger.LogDebug($"goelocation {geocoderAddressStr} updated ,customer :{partner.Info.Key}");
                    updatedCustomers.Add(partner.Info);
                }
                else
                {
                    notRequireCounter++;
                }

                if (cancellationToken.IsCancellationRequested)
                    break;
            }

            var cKeys = updatedCustomers.Count > 0
                ? updatedCustomers.Select(x => x.Key).Aggregate((x1, x2) => $"{x1}, {x2}")
                : "";
            _logger.LogInformation(
                $"finish task , call counter={callCounter} ,{updatedCustomers.Count} updated," +
                $" {notRequireCounter} not requires any update --- {cKeys}\n");
        }


        public Task GetTask(CancellationToken cancellationToken = default)
        {
            const int retryIntervalMinutes = 300; //TODO configuration file
            const int intervalMinutes = 600;
            return new Task(
                async () =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        try
                        {
                            await UpdateBusinessPartnersGeoLocationAsync(cancellationToken);
                            _logger.LogInformation($"start again in {intervalMinutes} minutes");
                            Task.Delay(TimeSpan.FromMinutes(intervalMinutes), cancellationToken)
                                .Wait(cancellationToken);
                        }
                        catch (Exception e)
                        {
                            //error!! try again in retryIntervalMinutes minutes
                            _logger.LogError($"{e.Message} --- try again in {retryIntervalMinutes} minutes");
                            Task.Delay(TimeSpan.FromMinutes(retryIntervalMinutes), cancellationToken)
                                .Wait(cancellationToken);
                        }
                    }
                }, cancellationToken, TaskCreationOptions.LongRunning);
        }
    }
}