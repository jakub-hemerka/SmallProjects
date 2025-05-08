namespace Playlist;

public record TrackModel
{
    public string Title { get; }
    public string Artist { get; }
    public TimeSpan Duration { get; }
    public string ExportString => $"{Title};{Artist};{Duration.TotalSeconds}";

    public TrackModel(string title, string artist, TimeSpan duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }

    public override string ToString()
    {
        return $"{Title} by {Artist} ({Duration:c})";
    }
}