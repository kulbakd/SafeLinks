using SafeLinks.Core.Application.Responses.Entities;

namespace SafeLinks.Core.Application.Features.Shortcuts.Commands;

public class GenerateShortcutResponse
{
    public string ShortGuid { get; set; }
    public string EditUrlRelative { get; set; }
}