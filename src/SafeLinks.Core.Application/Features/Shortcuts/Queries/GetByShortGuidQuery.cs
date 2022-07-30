using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SafeLinks.shared.Operations;
using SafeLinks.Core.Application.Interfaces.Repositories;
using SafeLinks.Core.Application.Responses.Entities;
using SafeLinks.Core.Domain.Entities;

namespace SafeLinks.Core.Application.Features.Shortcuts.Queries;

public class GetByShortGuidQuery : IRequest<Result<ShortcutResponse>>
{
    [Required]
    public string ShortGuid { get; set; }
    public bool EnforceEditGuid { get; set; }
    public string? EditGuid { get; set; }
}

internal class GetCompanyByIdQueryHandler : IRequestHandler<GetByShortGuidQuery, Result<ShortcutResponse>>
{
    private readonly IRepository<Shortcut> _shortcutRepository;
    private readonly IMapper _mapper;

    public GetCompanyByIdQueryHandler(
        IRepository<Shortcut> shortcutRepository,
        IMapper mapper)
    {
        _shortcutRepository = shortcutRepository;
        _mapper = mapper;
    }

    public async Task<Result<ShortcutResponse>> Handle(GetByShortGuidQuery query, CancellationToken cancellationToken)
    {
        var shortcut = await _shortcutRepository.Entities
            .Include(s => s.Link)
            .ThenInclude(l => l.SafetyAnalysis)
            .FirstOrDefaultAsync(
                s => s.ShortGuid == query.ShortGuid && (!query.EnforceEditGuid || s.EditGuid == query.EditGuid),
                cancellationToken);

        if (shortcut == null)
        {
            return Result<ShortcutResponse>.Fail("Shortcut not found.");
        }

        var mappedShortcut = _mapper.Map<ShortcutResponse>(shortcut);

        return Result<ShortcutResponse>.Success(mappedShortcut);
    }
}