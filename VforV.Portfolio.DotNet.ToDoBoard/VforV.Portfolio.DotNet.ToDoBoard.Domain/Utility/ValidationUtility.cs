using System.Collections.Immutable;
using FluentValidation.Results;

namespace VforV.Portfolio.DotNet.ToDoBoard.Domain.Utility;

internal static class ValidationUtility
{
    public static IImmutableList<string> GetErrors(this ValidationResult validationResult)
    {
        return validationResult
            .Errors
            .Select(e => $"'{e.PropertyName}' - {e.ErrorMessage}")
            .ToImmutableList();
    }

    public static IImmutableList<string> GetDebugErrors(this ValidationResult validationResult)
    {
        return validationResult
            .Errors
            .Select(e => $"'{e.PropertyName}' : '{e.AttemptedValue}' - {e.ErrorMessage} [{e.ErrorCode}, {e.Severity}]")
            .ToImmutableList();
    }
}