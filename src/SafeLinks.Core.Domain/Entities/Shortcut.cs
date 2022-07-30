using System.ComponentModel.DataAnnotations.Schema;
using SafeLinks.Core.Domain.Contracts;

namespace SafeLinks.Core.Domain.Entities;

public class Shortcut : Entity<int>
{
    public string ShortGuid { get; set; } = string.Empty;
    public string EditGuid { get; set; } = string.Empty;

    [ForeignKey("Link")]
    public int LinkId { get; set; }
    public Link Link { get; set; }
}
