using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBatch7.Domains
{
    [Table("department")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("department_name")]
        public required string Department_name { get; set; }

        [Column("created_date")]
        public DateTime Created_date { get; set; }
        [Column("updated_date")]
        public DateTime? Updated_date { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;

    }
}
