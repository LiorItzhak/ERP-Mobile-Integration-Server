
// ReSharper disable ClassNeverInstantiated.Global
namespace Web_Api.DTOs
{
    public class AttachmentDto
    {
        public int? AttachmentsCode { get; set; }
        public int? Num { get; set; }
        public string FileName { get; set; }
        public string Ext { get; set; }
        public string CreationDate { get; set; }
    }
}