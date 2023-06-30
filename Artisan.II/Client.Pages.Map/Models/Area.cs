namespace Artisan.II.Client.Pages.Map.Models;

public readonly record struct Area(Coordinates TopLeft, Coordinates BottomRight)
{
    public Coordinates TopRight => (TopLeft.Latitude, BottomRight.Longitude);
    public Coordinates BottomLeft => (BottomRight.Latitude, TopLeft.Longitude);

    public float Bottom => BottomLeft.Latitude;
    public float Top => TopRight.Latitude;
    public float Left => BottomLeft.Longitude;
    public float Right => TopRight.Longitude;
    
    public float LatitudeSpan => Math.Abs(Top - Bottom);
    public float LongitudeSpan => Math.Abs(Left - Right);

    public Coordinates GetRandomPoint(Random? random = null)
    {
        random ??= Random.Shared;
        float lat = LatitudeSpan * random.NextSingle() + Bottom;
        float lon = LongitudeSpan * random.NextSingle() + Left;
        return (lat, lon);
    }

    /// <summary>
    /// Creates an area that covers <paramref name="center"/> and <paramref name="latitudeOffset"/> and
    /// <paramref name="longitudeOffset"/> around it.
    /// </summary>
    /// <param name="center">The center point.</param>
    /// <param name="latitudeOffset">The distance that <see cref="Area"/> extends in north and south directions each.</param>
    /// <param name="longitudeOffset">The distance that <see cref="Area"/> extends in east and west directions each.</param>
    public Area(Coordinates center, float latitudeOffset, float longitudeOffset) : this(
        (center.Latitude - latitudeOffset, center.Longitude - longitudeOffset), 
        (center.Latitude + latitudeOffset, center.Longitude + longitudeOffset))
    { }
}