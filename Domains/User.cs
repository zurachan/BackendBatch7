using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBatch7.Domains
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

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

        [Column("created_date")]
        public DateTime Created_date { get; set; }

        [Column("updated_date")]
        public DateTime? Updated_date { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
