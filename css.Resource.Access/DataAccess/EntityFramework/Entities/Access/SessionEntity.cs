using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace css.Resource.Access.DataAccess.EntityFramework.Entities.Access
{
    [Table("Session")]
    public class SessionEntity
    {
        [Key]
        public long SessionId { get; set; }

        public string SessionKey { get; set; }

        public DateTime CreatedDateTimeUtc { get; set; }

        public DateTime LastAccessedDateTimeUtc { get; set; }
    }
}
