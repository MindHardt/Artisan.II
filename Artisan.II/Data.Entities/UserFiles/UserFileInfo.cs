namespace Artisan.II.Data.Entities.UserFiles;

public class UserFileInfo
{
    public required string Name { get; set; }
    public required UserFileScope Scope { get; set; }
    public required string ContentType { get; set; }


    public static UserFileInfo FromUserFile(UserFile file) => new()
    {
        ContentType = file.ContentType,
        Name = file.Name,
        Scope = file.Scope
    };
}