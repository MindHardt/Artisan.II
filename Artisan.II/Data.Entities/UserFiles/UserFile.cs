namespace Artisan.II.Data.Entities.UserFiles;

public record UserFile
{
    public required string Name { get; set; }
    public UserFileScope Scope { get; set; } = UserFileScope.Misc;
    public required byte[] Content { get; set; }
    
    public required string ContentType { get; set; }
}