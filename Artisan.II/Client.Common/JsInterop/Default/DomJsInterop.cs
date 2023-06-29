using Artisan.II.Client.Common.JsInterop.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Artisan.II.Client.Common.JsInterop.Default;

public class DomJsInterop : JsInteropBase, IDomJsInterop
{
    public DomJsInterop(IJSRuntime jsRuntime) : base(jsRuntime)
    {
    }

    protected override string JsFileName => "js/dom.js";
    
    public async ValueTask ReplayAnimationAsync(ElementReference element, params string[] classNames)
    {
        var module = await GetModuleAsync();
        await module.InvokeVoidAsync("replayAnimation", element, classNames);
    }
}