using System;

namespace DataAccessLayer.Entities
{
    public class GeoLocation :Entity
    {
        public virtual double? Latitude { get; set; }

        public virtual double? Longitude { get; set; }
        public virtual string Address { get; set; }
        
        
        public bool HasLocation()
        {
            return (Latitude.HasValue && Longitude.HasValue);
        }
    }

    public class SapGeoLocation : GeoLocation
    {
        // SAP GlpLocNum is a 50 chars string, temporarily I save the location as a string value

        private const string Delimiter = "|,|";
        private const string NoLocationMarker = "NO_LOCATION";

        private string _address = null;
        private double? _latitude = null;
        private double? _longitude = null;
        
        public string LocationString { get; set; }

        public override  double? Latitude
        {
            get => _latitude ?? (double?) Calc(0);
            set => _latitude = value;
        }

        public override   double? Longitude
        {
            get => _longitude ?? (double?) Calc(1);
            set => _longitude = value;
        }

        public override  string Address
        {
            get => _address ?? (string) Calc(2);
            set => _address = value;
        }

        private object Calc(int returnIndex)
        {
            try
            {
                if (!_latitude.HasValue && !_longitude.HasValue && _address == null)
                {
                    var l = LocationString.Split(Delimiter);
                    switch (l.Length)
                    {
                        case 3:
                            _latitude = Convert.ToDouble(l[0]);
                            _longitude = Convert.ToDouble(l[1]);
                            _address = l[2];
                            break;
                        case 2 when l[0] == NoLocationMarker:
                            _address = l[1];
                            break;
                        default:
                            throw new Exception($"location string invalid: {LocationString}");
                    }
                }
            }
            catch
            {
                _latitude = null;
                _longitude = null;
                _address = null;
            }

            if (returnIndex == 0 || returnIndex == 1)
                return returnIndex == 0 ? _latitude : _longitude;
            return _address;
        }

        public string ToLocationString()
        {
            // 20 + 7 + 7 = 34 - max string length
            // NoLocationMarker = 11
            // Delimiter = 3
            var address =string.IsNullOrEmpty( Address) == false? Address.Substring(0,
                Math.Min(Address.Length, 20)) : Address;
            var latitude = Latitude.HasValue ?  Math.Round(Convert.ToDecimal(Latitude), 7) : (decimal?) null;
            var longitude = Longitude.HasValue ?  Math.Round(Convert.ToDecimal(Longitude), 7) : (decimal?) null;

            return HasLocation()
                ? $"{latitude}{Delimiter}{longitude}{Delimiter}{address}"
                : $"{NoLocationMarker}{Delimiter}{address}";
        }

        
        public static SapGeoLocation From(GeoLocation geoLocation)
        {
            if (geoLocation == null)
                return new SapGeoLocation();
            return new SapGeoLocation
            {
                Address = geoLocation.Address,
                Latitude = geoLocation.Latitude,
                Longitude = geoLocation.Longitude
            };
        }
    }

}