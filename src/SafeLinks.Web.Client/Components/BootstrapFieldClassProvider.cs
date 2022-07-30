using Microsoft.AspNetCore.Components.Forms;
using SafeLinks.Core.Application.Features.Shortcuts.Commands;

namespace SafeLinks.Web.Client.Components;

public class BootstrapFieldClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, 
        in FieldIdentifier fieldIdentifier)
    {
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        if (fieldIdentifier.Model is GenerateShortcutCommand)
        {
            return isValid ? "" : "is-invalid";
        }

        return isValid ? "is-valid" : "is-invalid";
    }
}