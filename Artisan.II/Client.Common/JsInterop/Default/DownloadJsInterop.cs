using Artisan.II.Client.Common.JsInterop.Core;
using Microsoft.JSInterop;

namespace Artisan.II.Client.Common.JsInterop.Default;

public class DownloadJsInterop : 
    JsInteropBase,
    IDownloadJsInterop
{
    public DownloadJsInterop(IJSRuntime jsRuntime) : base(jsRuntime)
    {
    }

    protected override string JsFileName => "js/download.js";
    
    public async Task DownloadAsync(Stream stream, string fileName)
    {
        var module = await GetModuleAsync();
        DotNetStreamReference streamRef = new(stream);
        
        await module.InvokeVoidAsync("downloadFile", streamRef, fileName);
    }
}