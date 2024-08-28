using System.Linq.Expressions;
using Microsoft.AspNetCore.Components.Forms;

namespace Stunt.Context;

public static class EditContextExtensions
{
    public static void AddValidationMessage<T>(this EditContext editContext, Expression<Func<T>> accessor, string message)
    {
        var fieldIdentifier = FieldIdentifier.Create(accessor);
        var messages = editContext.GetValidationMessages(fieldIdentifier);
        if (!messages.Contains(message))
        {
            var messagesToAdd = new List<string> { message };
            editContext.NotifyValidationStateChanged();
            editContext.NotifyFieldChanged(fieldIdentifier);
        }
    }
}