using System;
using System.Collections.Generic;

namespace DataAccessLayer.SAPHandler.SqlHandler.Models
{
    public partial class ATC1
    {
        public int AbsEntry { get; set; }
        public int Line { get; set; }
        public string srcPath { get; set; }
        public string trgtPath { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public DateTime? Date { get; set; }
        public int? UsrID { get; set; }
        public string Copied { get; set; }
        public string Override { get; set; }
        public string subPath { get; set; }
    }
}
