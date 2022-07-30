using Microsoft.AspNetCore.Components;
using SafeLinks.Core.Application.Features.Shortcuts.Queries;
using SafeLinks.Web.Client.ViewModels;

namespace SafeLinks.Web.Client.Pages.Redirector;

public partial class Redirect
{
    [Parameter]
    public string ShortcutGuid { get; set; }
    
    private bool ShowLoading { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var shortened = await _mediator.Send(new GetByShortGuidQuery{ShortGuid = ShortcutGuid});

        if (shortened.Successful && !string.IsNullOrWhiteSpace(shortened.Data?.Link.Url))
        {
            _navigationManager.NavigateTo(shortened.Data.Link.Url);
        }
    }
}