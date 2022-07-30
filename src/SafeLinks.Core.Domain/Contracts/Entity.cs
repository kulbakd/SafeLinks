namespace SafeLinks.Core.Domain.Contracts;

public class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}