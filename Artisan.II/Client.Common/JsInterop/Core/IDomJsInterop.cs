using Microsoft.AspNetCore.Components;

namespace Artisan.II.Client.Common.JsInterop.Core;

public interface IDomJsInterop
{
    /// <summary>
    /// Removes classes specified by <paramref name="classNames"/> from the <paramref name="element"/>
    /// and adds them back after a short delay.
    /// This ensures that any animations in those classes are played again.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="classNames"></param>
    /// <returns></returns>
    public ValueTask ReplayAnimationAsync(ElementReference element, params string[] classNames);

    /// <summary>
    /// Removes class specified by <paramref name="className"/> from the <paramref name="element"/>
    /// and adds it back after a short delay.
    /// This ensures that any animations in those classes are played again.
    /// </summary>
    /// <param name="element"></param>
    /// <param name="className"></param>
    /// <returns></returns>
    public ValueTask ReplayAnimationAsync(ElementReference element, string className = "animate") =>
        ReplayAnimationAsync(element, new[] { className });
}