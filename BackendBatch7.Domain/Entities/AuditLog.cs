using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBatch7.Domain.Entities
{
    [Table("audit_log")]
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("user", TypeName = "varchar(200)")]
        public required string UserEmail { get; set; } = "System";

        [Required]
        [Column("entity", TypeName = "varchar(100)")]
        public required string EntityName { get; set; }

        [Required]
        [Column("action", TypeName = "varchar(20)")]
        public required string Action { get; set; }

        [Required]
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Column("changes", TypeName = "nvarchar(max)")]
        public required string Changes { get; set; }
    }
}
