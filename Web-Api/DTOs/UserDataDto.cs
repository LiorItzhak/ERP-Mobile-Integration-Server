namespace Web_Api.DTOs
{
    public class UserDataDto
    {
        public int UserId { get; set; }
        public string BusinessPartnerCode { get; set; }
        public bool IsRead { get; set; }
        public bool IsFavorite { get; set; }
        public string LastModified { get; set; }
    }
}