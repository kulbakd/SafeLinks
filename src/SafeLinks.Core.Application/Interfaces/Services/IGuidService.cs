using SafeLinks.Core.Domain.Entities;

namespace SafeLinks.Core.Application.Interfaces.Services;

public interface IGuidService
{
    string GenerateGuid();
    string GenerateShortGuidForId(int id);
}