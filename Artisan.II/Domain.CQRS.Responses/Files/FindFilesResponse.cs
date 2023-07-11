using Artisan.II.Data.Entities.UserFiles;

namespace Artisan.II.Domain.CQRS.Responses.Files;

public record FindFilesResponse
{
    public required UserFileInfo[] Files { get; set; }
}