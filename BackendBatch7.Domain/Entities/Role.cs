using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBatch7.Domain.Entities
{
    [Table("roles")]
    public class Role : AuditEntity<int>
    {
        [Required]
        [StringLength(100)]
        [Column("role_name")]
        public required string Role_name { get; set; }
    }
}
