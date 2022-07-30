using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using AutoMapper;
using MediatR;
using SafeLinks.shared.Operations;
using SafeLinks.Core.Application.Interfaces.Repositories;
using SafeLinks.Core.Application.Interfaces.Services;
using SafeLinks.Core.Application.Responses.Entities;
using SafeLinks.Core.Domain.Entities;

namespace SafeLinks.Core.Application.Features.Shortcuts.Commands;

public partial class GenerateShortcutCommand : IRequest<Result<GenerateShortcutResponse>>
{
    [Required(ErrorMessage = "Please enter a valid URL.")]
    [RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:(?:\.[\w\.-]+)+|(?:\:\d+)+)[\w\-\._~:\/?#[\]@!\$&'\(\)\*\+,;=.]+$", ErrorMessage = "Please enter a valid URL.")]
    public string Url { get; set; }
}

internal class GenerateShortcutCommandHandler : IRequestHandler<GenerateShortcutCommand, Result<GenerateShortcutResponse>>
{
    private readonly IRepository<Shortcut> _shortcutRepository;
    private readonly IRepository<Link> _linkRepository;
    private readonly IGuidService _guidService;
    private readonly IMapper _mapper;

    public GenerateShortcutCommandHandler(
        IRepository<Shortcut> shortcutRepository,
        IRepository<Link> linkRepository,
        IGuidService guidService,
        IMapper mapper)
    {
        _shortcutRepository = shortcutRepository;
        _linkRepository = linkRepository;
        _guidService = guidService;
        _mapper = mapper;
    }
    
    public async Task<Result<GenerateShortcutResponse>> Handle(GenerateShortcutCommand command, CancellationToken cancellationToken)
    {
        if (!Regex.IsMatch(command.Url, "^https?://"))
        {
            command.Url = $"http://{command.Url}";
        }

        var existingLink = _linkRepository.Find(l => l.Url == command.Url).FirstOrDefault();

        if (existingLink == null)
        {
            existingLink = new Link
            {
                Url = command.Url
            };
        }

        var shortcut = new Shortcut
        {
            EditGuid = _guidService.GenerateGuid(),
            Link = existingLink
        };

        await using var transaction = await _shortcutRepository.BeginTransactionAsync(cancellationToken);

        try
        {
            shortcut = await _shortcutRepository.AddAsync(shortcut);
            await _shortcutRepository.SaveChangesAsync();

            shortcut.ShortGuid = _guidService.GenerateShortGuidForId(shortcut.Id);

            _shortcutRepository.Update(shortcut);
            await _shortcutRepository.SaveChangesAsync();

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            return await Task.FromResult(Result<GenerateShortcutResponse>.Fail("There was a problem shortening your link. Please try again."));
        }

        var result = _mapper.Map<GenerateShortcutResponse>(shortcut);

        return await Task.FromResult(Result<GenerateShortcutResponse>.Success(result));
    }
}