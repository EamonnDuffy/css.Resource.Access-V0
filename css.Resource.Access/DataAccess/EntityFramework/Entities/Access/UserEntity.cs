using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace css.Resource.Access.DataAccess.EntityFramework.Entities.Access
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public long UserId { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedDateTimeUtc { get; set; }

        public DateTime UpdatedDateTimeUtc { get; set; }
    }
}
