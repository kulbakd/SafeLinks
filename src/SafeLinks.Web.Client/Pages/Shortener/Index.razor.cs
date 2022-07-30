using Microsoft.AspNetCore.Components.Forms;
using SafeLinks.Core.Application.Features.Shortcuts.Commands;
using SafeLinks.Web.Client.Components;

namespace SafeLinks.Web.Client.Pages.Shortener;

public partial class Index
{
    GenerateShortcutCommand generateShortcutCommand = new GenerateShortcutCommand();

    private EditContext editContext;

    private bool ShowShortenError { get; set; }
    private string ShortenError { get; set; } = string.Empty;

    private Dictionary<string, object> UrlInputAttributes { get; set; } =
        new()
        {
            { "id", "url-input" },
            { "class", "form-control" },
            { "placeholder", "Your URL" }
        };

    protected override void OnInitialized()
    {
        editContext = new EditContext(generateShortcutCommand);
        editContext.SetFieldCssClassProvider(new BootstrapFieldClassProvider());
    }

    private async Task ShortenUrl()
    {
        ShowShortenError = false;
        StateHasChanged();

        var shortened = await _mediator.Send(generateShortcutCommand);
        if (shortened.Successful && !string.IsNullOrWhiteSpace(shortened.Data?.EditUrlRelative))
        {
            _navigationManager.NavigateTo(shortened.Data.EditUrlRelative);

            return;
        }

        ShowShortenError = true;
        ShortenError = shortened.Message ?? "Unknown error occured.";
    }
}