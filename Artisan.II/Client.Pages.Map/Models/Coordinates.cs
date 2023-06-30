namespace Artisan.II.Client.Pages.Map.Models;

public readonly record struct Coordinates(float Latitude, float Longitude)
{
    public static implicit operator Coordinates((float Latitude, float Longitude) tuple) 
        => new(tuple.Latitude, tuple.Longitude);
}