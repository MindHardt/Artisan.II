namespace Artisan.II.Client.Common.JsInterop.Core;

public interface IDownloadJsInterop
{
    /// <summary>
    /// Downloads file specified by contents in <paramref name="stream"/> with downloadable name <paramref name="fileName"/>.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public Task DownloadAsync(Stream stream, string fileName);
}