using Artisan.II.Domain.CQRS.Responses.Files;
using MediatR;

namespace Artisan.II.Domain.CQRS.Requests.Files;

public record GetFileRequest : IRequest<GetFileResponse>
{
    public required string FileName { get; set; }
}
