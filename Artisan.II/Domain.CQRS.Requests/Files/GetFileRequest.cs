using Artisan.II.Data.Entities.UserFiles;
using Artisan.II.Domain.CQRS.Responses.Files;
using MediatR;

namespace Artisan.II.Domain.CQRS.Requests.Files;

public record GetFileRequest : IRequest<GetFileResponse>
{
    public required UserFileScope Scope { get; set; }
    public required string FileName { get; set; }
}
