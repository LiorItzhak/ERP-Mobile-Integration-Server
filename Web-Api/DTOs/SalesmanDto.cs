using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataAccessLayer.Entities.SalesmanEntity;

namespace Web_Api.DTOs
{
    public class SalesmanDto
    {
        public string Name { get; set; }
        public int Sn { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

    }
}
