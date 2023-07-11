namespace Artisan.II.Data.Entities.UserFiles;

[Flags] 
public enum UserFileScope
{
    /// <summary>
    /// Undefined scope.
    /// </summary>
    Misc = 0,
    /// <summary>
    /// User or character avatar.
    /// </summary>
    Avatar = 1<<1,
    /// <summary>
    /// The attachment to the message.
    /// </summary>
    Attachment = 1<<2,
}