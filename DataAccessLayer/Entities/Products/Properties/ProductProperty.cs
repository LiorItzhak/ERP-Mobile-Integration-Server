using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities.Products.Properties
{
    public  class ProductPropertyEntity
    {
        public string Code { get; set; }
        public object DefaultValue { get; set; }
        public bool Updateable { get; set; }

        public enum PropertyType { Decimal,Int,Text,Choice,Date}
        public PropertyType Type { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
        public string[] Choices { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? MaxDaysFromNow { get; set; }
        //Unit of measurement
        public string UOM { get; set; }

    }

    //public class IntProductProperty : ProductProperty
    //{
    //    public override PropertyType Type => PropertyType.Int;

    //    public int? MinValue { get; set; }
    //    public int? MaxValue { get; set; }

    //}

    //public class DecimalProductProperty : ProductProperty
    //{
    //    public override PropertyType Type => PropertyType.Decimal;

    //    public int? MinValue { get; set; }
    //    public int? MaxValue { get; set; }
    //    public int? Decimal { get; set; }

    //}

    //public class TextProductProperty : ProductProperty
    //{
    //    public override PropertyType Type => PropertyType.Text;


    //}

    //public class ChoiceProductProperty : ProductProperty
    //{
    //    public override PropertyType Type => PropertyType.Choice;

    //    public string[] Choices { get; set; }

    //}

    //public class DateProductProperty : ProductProperty
    //{
    //    public override PropertyType Type => PropertyType.Date;

    //    public DateTime? FromDate { get; set; }
    //    public DateTime? ToDate { get; set; }
    //    public DateTime? MaxDaysFromNow { get; set; }
    //}
}
