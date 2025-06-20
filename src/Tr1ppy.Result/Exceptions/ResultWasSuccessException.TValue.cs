namespace Tr1ppy.Result.Exceptions;

public sealed class ResultWasSuccessException<TValue>(TValue value, string? message = default) : ResultWasSuccessException(message)
{
    public TValue Value { get; init; } = value;
}
