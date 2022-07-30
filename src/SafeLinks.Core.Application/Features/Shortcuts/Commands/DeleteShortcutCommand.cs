using System.ComponentModel.DataAnnotations;
using MediatR;
using SafeLinks.shared.Operations;
using SafeLinks.Core.Application.Interfaces.Repositories;
using SafeLinks.Core.Domain.Entities;

namespace SafeLinks.Core.Application.Features.Shortcuts.Commands;

public partial class DeleteShortcutCommand : IRequest<Result>
{
    [Required]
    public string ShortGuid { get; set; }
    [Required]
    public string EditGuid { get; set; }
}

internal class DeleteShortcutCommandHandler : IRequestHandler<DeleteShortcutCommand, Result>
{
    private readonly IRepository<Shortcut> _shortcutRepository;

    public DeleteShortcutCommandHandler(
        IRepository<Shortcut> shortcutRepository)
    {
        _shortcutRepository = shortcutRepository;
    }
    
    public async Task<Result> Handle(DeleteShortcutCommand command, CancellationToken cancellationToken)
    {
        var shortcut = _shortcutRepository.Find(s => s.ShortGuid == command.ShortGuid).FirstOrDefault();

        if (shortcut == null)
        {
            return await Task.FromResult(Result.Fail("Shortened link not found."));
        }

        if (shortcut.EditGuid != command.EditGuid)
        {
            return await Task.FromResult(Result.Fail("Invalid delete code."));
        }

        _shortcutRepository.Delete(shortcut);
        await _shortcutRepository.SaveChangesAsync();

        return await Task.FromResult(Result.Success());
    }
}