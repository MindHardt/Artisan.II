using Artisan.II.Domain.CQRS.Requests.Files;
using Artisan.II.Domain.CQRS.Responses.Files;
using Artisan.II.Domain.Exceptions;
using Artisan.II.Domain.Services.Core;
using MediatR;

namespace Artisan.II.Domain.CQRS.Handlers.Files;

public class GetFileRequestHandler : IRequestHandler<GetFileRequest, GetFileResponse>
{
    private readonly IUserFileService _userFileService;

    public GetFileRequestHandler(IUserFileService userFileService)
    {
        _userFileService = userFileService;
    }

    public async Task<GetFileResponse> Handle(GetFileRequest request, CancellationToken cancellationToken)
    {
        var file = await _userFileService.GetFile(request.Scope, request.FileName);
        NotFoundException.ThrowIfNull(file);

        return new GetFileResponse
        {
            File = file,
        };
    }
}
