
namespace CleanArchTemplate.Domain.Common
{
    public abstract class BaseAuditableEntity<T> : BaseEntity<T>
    {
        public DateTimeOffset CreatedAt { get;  }
        public DateTimeOffset UpdatedAt { get; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
