using Artisan.II.Data.Entities.UserFiles;

namespace Artisan.II.Domain.CQRS.Responses.Files;

public record PostFileResponse
{
    public required UserFileInfo SavedFile { get; set; }
}