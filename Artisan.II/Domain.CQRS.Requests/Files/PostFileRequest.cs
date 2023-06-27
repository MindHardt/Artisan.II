using Artisan.II.Data.Entities.UserFiles;
using Artisan.II.Domain.CQRS.Responses.Files;
using MediatR;

namespace Artisan.II.Domain.CQRS.Requests.Files;

public record PostFileRequest : IRequest<PostFileResponse>
{
    public required UserFile File { get; set; }
}