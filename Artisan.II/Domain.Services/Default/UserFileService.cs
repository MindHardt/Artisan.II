using Artisan.II.Data.Abstractions;
using Artisan.II.Data.Entities.UserFiles;
using Artisan.II.Domain.Services.Core;

namespace Artisan.II.Domain.Services.Default;

public class UserFileService : IUserFileService
{
    private const int MaxFileInfos = 25;
    
    private readonly IUserFileRepository _repository;

    public UserFileService(IUserFileRepository repository)
    {
        _repository = repository;
    }


    public ValueTask<UserFile?> GetByName(string fileName)
    {
        return _repository.GetByName(fileName);
    }

    public async ValueTask<UserFile> SaveFile(UserFile file)
    {
        string newFileName = Path.GetRandomFileName() + Path.GetExtension(file.Name);
        file.Name = newFileName;
        return await _repository.SaveFile(file);
    }

    public async ValueTask<IReadOnlyCollection<UserFileInfo>> FindFiles(string prompt)
    {
        return await _repository.FindFiles(prompt, MaxFileInfos);
    }
}