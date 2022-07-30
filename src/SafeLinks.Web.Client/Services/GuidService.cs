using Microsoft.AspNetCore.WebUtilities;
using SafeLinks.Core.Application.Interfaces.Services;
using SafeLinks.Web.Client.Extensions;

namespace SafeLinks.Web.Client.Services;

public class GuidService : IGuidService
{
    public string GenerateGuid()
    {
        return Guid.NewGuid().ToString();
    }

    public string GenerateShortGuidForId(int id)
    {
        return (1296 + id).ToBase36(); // return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id));
    }
}