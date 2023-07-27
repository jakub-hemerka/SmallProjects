using System.Text;

namespace Playlist;
public class PlaylistModel
{
    public string Title { get; init; }
    public List<TrackModel> Tracks { get; set; }

    private readonly Random _rand;
    private readonly string _filepath;

    public PlaylistModel(string title, string filename)
    {
        _rand = new();
        Title = title;
        _filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Programování", "ExterniData", filename);
        Tracks = new();
    }

    public void Load()
    {
        string[] lines = File.ReadAllLines(_filepath);

        if (lines.Length < 1)
        {
            return;
        }

        foreach (string line in lines)
        {
            string[] vals = line.Split(';');

            if (vals.Length != 3 || !int.TryParse(vals[2], out int duration))
            {
                continue;
            }

            Tracks.Add(new TrackModel(vals[0], vals[1], TimeSpan.FromSeconds(duration)));
        }
    }

    public void Save()
    {
        List<string> lines = new();

        foreach (TrackModel track in Tracks)
        {
            lines.Add($"{track.Title};{track.Artist};{track.Duration.TotalSeconds}");
        }

        File.WriteAllLines(_filepath, lines, Encoding.UTF8);
    }

    public void Enqueue(TrackModel track)
    {
        Tracks.Add(track);
    }

    public void Remove(TrackModel track)
    {
        _ = Tracks.Remove(track);
    }

    public void View()
    {
        Console.WriteLine($"Název playlistu: {Title}");
        Console.WriteLine("=========================");
        foreach (TrackModel track in Tracks)
        {
            Console.WriteLine($"{track.Title} by {track.Artist} ({track.Duration:c})");
        }
    }

    public void Shuffle()
    {
        _ = Tracks.OrderBy(x => _rand.Next());
    }

    public void GetNumberOfTracks()
    {
        Console.WriteLine($"This playlist has {Tracks.Count} tracks");
    }

    public void GetDuration()
    {
        TimeSpan total = new();
        foreach (TrackModel track in Tracks)
        {
            total += track.Duration;
        }

        Console.WriteLine($"Total duration of this playlist is {total:c}");
    }

    public void Reset()
    {
        Tracks.Clear();
    }

    public void IsEmpty()
    {
        if (Tracks.Count == 0)
        {
            Console.WriteLine("Playlist is empty");
            return;
        }

        Console.WriteLine("Playlist is not empty");
    }
}