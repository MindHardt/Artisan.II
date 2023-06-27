using Artisan.II.Data.Entities.UserFiles;
using Artisan.II.Domain.CQRS.Requests.Files;
using Artisan.II.Domain.CQRS.Responses.Files;
using Artisan.II.Domain.Services.Core;
using MediatR;

namespace Artisan.II.Domain.CQRS.Handlers.Files;

public class PostFileRequestHandler : IRequestHandler<PostFileRequest, PostFileResponse>
{
    private readonly IUserFileService _userFileService;

    public PostFileRequestHandler(IUserFileService userFileService)
    {
        _userFileService = userFileService;
    }

    public async Task<PostFileResponse> Handle(PostFileRequest request, CancellationToken cancellationToken)
    {
        var savedFile = await _userFileService.SaveFile(request.File);
        var savedFileInfo = UserFileInfo.FromUserFile(savedFile);

        return new PostFileResponse
        {
            SavedFile = savedFileInfo
        };
    }
}