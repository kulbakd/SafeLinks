namespace SafeLinks.Web.Client.ViewModels;

public class ShortcutViewModel
{
    public string ShortcutUrl { get; set; } = "...";

    public LinkViewModel Link { get; set; } = new LinkViewModel();
}