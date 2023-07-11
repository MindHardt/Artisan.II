namespace Artisan.II.Server;

public static class Extensions
{
    public static async ValueTask<byte[]> ToByteArrayAsync(this Stream stream)
    {
        var ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        return ms.ToArray();
    }
}