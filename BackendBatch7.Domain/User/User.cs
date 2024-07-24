using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBatch7.Domain
{
    public class User : AuditEntity<int>
    {
        [Required]
        [StringLength(20)]
        [Column("first_name")]
        public required string First_name { get; set; }

        [Required]
        [StringLength(20)]
        [Column("last_name")]
        public required string Last_name { get; set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        public required string Email { get; set; }
    }
}
