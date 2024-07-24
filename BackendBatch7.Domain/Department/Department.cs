using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBatch7.Domain
{
    public class Department : AuditEntity<int>
    {
        [Required]
        [StringLength(100)]
        [Column("department_name")]
        public required string Department_name { get; set; }
    }
}
