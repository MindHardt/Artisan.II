using System.Reflection;

namespace Artisan.II.Client.Common.Utils;

/// <summary>
/// A class used to ease path access to Razor Class Libraries wwwroot files.
/// </summary>
public static class PathHelper
{
    /// <summary>
    /// Gets the full path to resource specified by <paramref name="relativePath"/>.
    /// </summary>
    /// <param name="relativePath">The path to file relative to project wwwroot.</param>
    /// <typeparam name="T">Any type in the target razor class library assembly.</typeparam>
    /// <returns></returns>
    public static string GetFullPath<T>(string relativePath) =>
        GetFullPath(typeof(T).Assembly, relativePath);

    /// <summary>
    /// Gets the full path to resource specified by <paramref name="relativePath"/>.
    /// </summary>
    /// <param name="type">Any type in the target razor class library assembly.</param>
    /// <param name="relativePath">The path to file relative to project wwwroot.</param>
    /// <returns></returns>
    public static string GetFullPath(Type type, string relativePath) =>
        GetFullPath(type.Assembly, relativePath);
    
    /// <summary>
    /// Gets the full path to resource specified by <paramref name="relativePath"/>.
    /// </summary>
    /// <param name="assembly">Target razor class library assembly.</param>
    /// <param name="relativePath">The path to file relative to project wwwroot.</param>
    /// <returns></returns>
    public static string GetFullPath(Assembly assembly, string relativePath) =>
        $"./_content/{assembly.GetName().Name}/{relativePath}";
}