namespace SafeLinks.Core.Application.Responses.Entities;

public class LinkResponse
{
    public string Url { get; set; }

    public SafetyAnalysisResponse? SafetyAnalysis { get; set; }
}