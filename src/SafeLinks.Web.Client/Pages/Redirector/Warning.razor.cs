using Microsoft.AspNetCore.Components;

namespace SafeLinks.Web.Client.Pages.Redirector;

public partial class Warning
{
    [Parameter]
    public string ShortcutGuid { get; set; }
}