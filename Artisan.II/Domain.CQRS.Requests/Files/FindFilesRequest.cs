using Artisan.II.Data.Entities.UserFiles;
using Artisan.II.Domain.CQRS.Responses.Files;
using MediatR;

namespace Artisan.II.Domain.CQRS.Requests.Files;

public record FindFilesRequest : IRequest<FindFilesResponse>
{
    public required string Prompt { get; set; }
    public UserFileScope? Scope { get; set; }
}