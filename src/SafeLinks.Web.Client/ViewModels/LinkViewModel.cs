namespace SafeLinks.Web.Client.ViewModels;

public class LinkViewModel
{
    public string Url { get; set; } = "...";

    public SafetyAnalysisViewModel SafetyAnalysis { get; set; } = new SafetyAnalysisViewModel();
}