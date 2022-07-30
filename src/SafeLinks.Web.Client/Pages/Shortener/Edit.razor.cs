using System.Net.Mime;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SafeLinks.Core.Application.Features.Shortcuts.Commands;
using SafeLinks.Core.Application.Features.Shortcuts.Queries;
using SafeLinks.Web.Client.ViewModels;

namespace SafeLinks.Web.Client.Pages.Shortener;

public partial class Edit
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; }

    [Parameter]
    public string ShortcutGuid { get; set; }

    [Parameter]
    public string EditGuid { get; set; }

    private ShortcutViewModel ShortcutViewModel { get; set; } = new ShortcutViewModel();

    private bool ShowDeleteConfirmation { get; set; }
    private bool ShowDeleteError { get; set; }
    private string DeleteError { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var shortened = await _mediator.Send(new GetByShortGuidQuery
        {
            ShortGuid = ShortcutGuid,
            EnforceEditGuid = true,
            EditGuid = EditGuid
        });

        if (shortened.Successful)
        {
            ShortcutViewModel.ShortcutUrl = $"{_navigationManager.BaseUri}{shortened.Data?.ShortGuid}";
            ShortcutViewModel.Link.Url = shortened.Data?.Link.Url ?? string.Empty;
        }
        else
        {
            _navigationManager.NavigateTo("/");
        }
    }
    
    private async Task CopyLinkToClipboard()
    {
        await _jsRuntime.InvokeVoidAsync("clipboardCopy.copyText", ShortcutViewModel.ShortcutUrl);
    }

    private async Task DeleteShortcut()
    {
        ShowDeleteError = false;
        StateHasChanged();

        var deleted = await _mediator.Send(new DeleteShortcutCommand
        {
            ShortGuid = ShortcutGuid,
            EditGuid = EditGuid
        });

        if (deleted.Successful)
        {
            _navigationManager.NavigateTo("/");
            return;
        }

        ShowDeleteError = true;
        DeleteError = deleted.Message ?? "Unknown error occured.";
    }
}