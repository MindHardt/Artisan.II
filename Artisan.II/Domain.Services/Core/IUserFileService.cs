using Artisan.II.Data.Entities.UserFiles;

namespace Artisan.II.Domain.Services.Core;

public interface IUserFileService
{
    /// <summary>
    /// Attempts to get the file with name equivalent to <paramref name="fileName"/>.
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>The found <see cref="UserFile"/> or <see langword="null"/> if none is found.</returns>
    public ValueTask<UserFile?> GetFile(UserFileScope scope, string fileName);
    
    /// <summary>
    /// Saves file to the database.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public ValueTask<UserFile> SaveFile(UserFile file);

    /// <summary>
    /// Finds all files that match <paramref name="prompt"/> and returns them as <see cref="UserFileInfo"/>.
    /// </summary>
    /// <param name="prompt">The part of file name.</param>
    /// <param name="scope">The optional <see cref="UserFileScope"/> to limit the</param>
    /// <returns></returns>
    public ValueTask<IReadOnlyCollection<UserFileInfo>> FindFiles(string prompt, UserFileScope? scope = null);
}