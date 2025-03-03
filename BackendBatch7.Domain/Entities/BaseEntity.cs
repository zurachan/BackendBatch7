using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBatch7.Domain.Entities
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }

    public interface IDeleteEntity
    {
        bool IsDeleted { get; set; }
    }

    public interface IDeleteEntity<T> : IBaseEntity<T>, IDeleteEntity
    {
    }

    public interface IAuditEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string? UpdatedBy { get; set; }
    }
    public interface IAuditEntity<T> : IAuditEntity, IDeleteEntity<T>
    {
    }

    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public virtual required T Id { get; set; }
    }

    public abstract class DeleteEntity<T> : BaseEntity<T>, IDeleteEntity<T>
    {
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }

    public abstract class AuditEntity<T> : DeleteEntity<T>, IAuditEntity<T>
    {
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; } = "System";
        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; } = null;
        [Column("updated_by")]
        public string? UpdatedBy { get; set; } = null;
    }
}
