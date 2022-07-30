using AutoMapper;
using SafeLinks.Core.Application.Features.Shortcuts.Commands;
using SafeLinks.Core.Application.Responses.Entities;
using SafeLinks.Core.Domain.Entities;

namespace SafeLinks.Core.Application.Mappings;

public class ApplicationDomainProfile : Profile
{
    public ApplicationDomainProfile()
    {
        CreateMap<Shortcut, GenerateShortcutResponse>()
            .ForMember(dest => dest.EditUrlRelative,
                opt => opt.MapFrom(src => $"/edit/{src.ShortGuid}/{src.EditGuid}"));
        CreateMap<Shortcut, ShortcutResponse>();
        CreateMap<Link, LinkResponse>();
        CreateMap<SafetyAnalysis, SafetyAnalysisResponse>();
    }
}