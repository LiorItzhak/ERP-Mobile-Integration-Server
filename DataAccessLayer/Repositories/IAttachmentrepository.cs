using System;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface IAttachmentRepository  : IWritableRepository<Attachment,IAttachmentRepository.AttachmentKey>
    {
        
        
        public class AttachmentKey
        {
            protected bool Equals(AttachmentKey other)
            {
                return Code == other.Code && Num == other.Num;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((AttachmentKey) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Code, Num);
            }

            public int Code { get; set; }
            public int Num { get; set; }


        }
    }
}