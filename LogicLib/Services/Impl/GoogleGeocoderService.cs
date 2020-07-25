using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Services.Impl
{
   public class GoogleGeocoderService : IGeocoderService
    {
        //check status
        //https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyC23Y1I9Gmcm86--lrQC4cRfS26QiNqHrA
        private readonly string _apiKey;
        private readonly GoogleGeocoder geocoder;
        public GoogleGeocoderService(string apiKey)
        {
            _apiKey = apiKey;
            geocoder = new GoogleGeocoder(apiKey);

        }
        public async Task<GeoLocation> GetGeoLocationFromAddress(string address)
        {
            var response = await geocoder.GeocodeAsync(address);
            var googleAddresses = response as GoogleAddress[] ?? response.ToArray();
            return googleAddresses
                .Select(x => new GeoLocation(x.Coordinates.Latitude, x.Coordinates.Longitude))
                .FirstOrDefault();
        }
    }
}
