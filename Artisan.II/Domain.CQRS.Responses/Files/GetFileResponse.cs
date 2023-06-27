using Artisan.II.Data.Entities.UserFiles;

namespace Artisan.II.Domain.CQRS.Responses.Files;

public record GetFileResponse
{
    public required UserFile File { get; set; }
}