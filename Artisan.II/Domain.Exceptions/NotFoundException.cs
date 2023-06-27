using System.Diagnostics.CodeAnalysis;

namespace Artisan.II.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string? message) : base(message ?? ExceptionResources.NotFoundException)
    {
    }

    public static void ThrowIfNull([NotNull] object? param, string? message = null)
    {
        if (param is null)
            throw new NotFoundException(message);
    }
}