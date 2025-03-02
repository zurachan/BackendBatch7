using BackendBatch7.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBatch7.Domain.Entities
{
    public class Permission : AuditEntity<int>
    {
        [Required]
        [Column("user_id")]
        public int User_id { get; set; }

        public virtual User? User { get; set; }

        [Required]
        [Column("role_id")]
        public int Role_id { get; set; }
        public virtual Role? Role { get; set; }

        [Required]
        [Column("department_id")]
        public int Department_id { get; set; }
        public virtual Department? Department { get; set; }
    }
}
