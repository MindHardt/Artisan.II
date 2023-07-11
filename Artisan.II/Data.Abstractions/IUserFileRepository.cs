using Artisan.II.Data.Entities.UserFiles;

namespace Artisan.II.Data.Abstractions;

public interface IUserFileRepository
{
    /// <summary>
    /// Attempts to get the file with name equivalent to <paramref name="fileName"/>.
    /// </summary>
    /// <param name="scope">The scope under which the file should be searched.</param>
    /// <param name="fileName"></param>
    /// <returns>The found <see cref="UserFile"/> or <see langword="null"/> if none is found.</returns>
    public ValueTask<UserFile?> GetByName(UserFileScope scope, string fileName);
    
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
    /// <param name="maximum">The maximum amount of fetched files.</param>
    /// <param name="scope">The optional scope to reduce the search area.</param>
    /// <returns></returns>
    public ValueTask<IReadOnlyCollection<UserFileInfo>> FindFiles(string prompt, int maximum, UserFileScope? scope = null);
}