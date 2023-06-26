namespace Artisan.II.Client.Common.Utils;

public static class PathHelper
{
    public static string GetFullPath<T>(string relativePath) =>
        GetFullPath(typeof(T), relativePath);
    
    public static string GetFullPath(Type type, string relativePath) =>
        $"./_content/{type.Assembly.GetName().Name}/{relativePath}";
}