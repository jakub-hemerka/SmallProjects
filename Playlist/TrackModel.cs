namespace Playlist;
public record TrackModel
{
    public string Title { get; init; }
    public string Artist { get; init; }
    public TimeSpan Duration { get; init; }

    public TrackModel(string title, string artist, TimeSpan duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }
}