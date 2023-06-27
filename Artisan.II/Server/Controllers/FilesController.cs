using Artisan.II.Data.Entities.UserFiles;
using Artisan.II.Domain.CQRS.Requests.Files;
using Artisan.II.Domain.CQRS.Responses.Files;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artisan.II.Server.Controllers;

// [Authorize]
[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{FileName:file}")]
    public async ValueTask<FileStreamResult> GetFile([FromRoute] GetFileRequest request)
    {
        var response = await _mediator.Send(request);
        return GetResult(response.File);
    }
    
    [HttpPost]
    public async ValueTask<PostFileResponse> PostFile(IFormFile file)
    {
        var content = new MemoryStream();
        await file.CopyToAsync(content);
        var userFile = new UserFile
        {
            Name = file.FileName,
            Content = content.ToArray(),
            ContentType = file.ContentType,
        };
        var request = new PostFileRequest { File = userFile };
        return await _mediator.Send(request);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public FileStreamResult GetResult(UserFile file) =>
        new(new MemoryStream(file.Content), file.ContentType);
}