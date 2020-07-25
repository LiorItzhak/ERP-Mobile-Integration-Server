using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLib.Services
{
    public interface IGeocoderService 
    {
        Task<GeoLocation> GetGeoLocationFromAddress(string address);
        

        
    }

    public class GeoLocation
    {
        public GeoLocation( double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
