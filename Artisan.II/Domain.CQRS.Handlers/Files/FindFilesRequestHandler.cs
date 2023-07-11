using Artisan.II.Data.Abstractions;
using Artisan.II.Domain.CQRS.Requests.Files;
using Artisan.II.Domain.CQRS.Responses.Files;
using Artisan.II.Domain.Services.Core;
using MediatR;

namespace Artisan.II.Domain.CQRS.Handlers.Files;

public class FindFilesRequestHandler : IRequestHandler<FindFilesRequest, FindFilesResponse>
{
    private readonly IUserFileService _userFileService;

    public FindFilesRequestHandler(IUserFileService userFileService)
    {
        _userFileService = userFileService;
    }


    public async Task<FindFilesResponse> Handle(FindFilesRequest request, CancellationToken cancellationToken)
    {
        var files = await _userFileService.FindFiles(request.Prompt, request.Scope);
        return new FindFilesResponse()
        {
            Files = files.ToArray()
        };
    }
}
