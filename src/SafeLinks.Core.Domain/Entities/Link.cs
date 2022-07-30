using System.ComponentModel.DataAnnotations.Schema;
using SafeLinks.Core.Domain.Contracts;

namespace SafeLinks.Core.Domain.Entities;

public class Link : Entity<int>
{
    public string Url { get; set; } = string.Empty;
    
    [ForeignKey("SafetyAnalysis")]
    public int? SafetyAnalysisId { get; set; }
    public SafetyAnalysis? SafetyAnalysis { get; set; }
}
