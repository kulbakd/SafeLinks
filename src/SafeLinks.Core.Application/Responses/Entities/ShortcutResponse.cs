namespace SafeLinks.Core.Application.Responses.Entities;

public class ShortcutResponse
{
    public string ShortGuid { get; set; } = string.Empty;

    public LinkResponse Link { get; set; }
}