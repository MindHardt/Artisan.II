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

    [HttpGet("{scope}/{fileName:exists}")]
    public async ValueTask<FileStreamResult> GetFile(
        [FromRoute] UserFileScope scope,
        [FromRoute] string fileName)
    {
        var request = new GetFileRequest()
        {
            Scope = scope,
            FileName = fileName
        };
        var response = await _mediator.Send(request);
        return GetResult(response.File);
    }
    
    [HttpPost("{scope}")]
    public async ValueTask<PostFileResponse> PostFile(
        [FromRoute] UserFileScope scope, 
        IFormFile file)
    {
        var userFile = new UserFile
        {
            Scope = scope,
            Name = file.FileName,
            Content = await file.OpenReadStream().ToByteArrayAsync(),  
            ContentType = file.ContentType,
        };
        var request = new PostFileRequest { File = userFile };
        return await _mediator.Send(request);
    }

    [HttpGet("like/{prompt}")]
    public async ValueTask<FindFilesResponse> FindFiles(
        [FromRoute] string prompt,
        [FromQuery] UserFileScope? scope = null)
    {
        var request = new FindFilesRequest
        {
            Prompt = prompt,
            Scope = scope
        };
        return await _mediator.Send(request);
    }

    private static FileStreamResult GetResult(UserFile file) =>
        new(new MemoryStream(file.Content), file.ContentType);
}