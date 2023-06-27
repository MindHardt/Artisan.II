using System.Diagnostics.CodeAnalysis;

namespace Artisan.II.Domain.Exceptions;

public class NotAllowedException : Exception
{
    public NotAllowedException(string? message = null) : base(message ?? ExceptionResources.NotAllowedException)
    {
    }
    
    public static void ThrowIfNull([NotNull] object? param, string? message = null)
    {
        if (param is null) throw new NotAllowedException(message);
    }

    public static void ThrowIf(bool check, string? message = null)
    {
        if (check) throw new NotAllowedException(message);
    }
}