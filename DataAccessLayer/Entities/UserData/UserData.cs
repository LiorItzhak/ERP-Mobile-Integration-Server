using System;

namespace DataAccessLayer.Entities.UserData
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class UserData
    {
        public int UserId { get; set; }//Key
        public string LeadSn { get; set; }//Key //TODO change to BusinessPartner

        public bool IsRead { get; set; }
        
        public bool IsFavorite { get; set; }
        public DateTime? LastModifiedUtc { get; set; }//TODO remove utc
    }
}