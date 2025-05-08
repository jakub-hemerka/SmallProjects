using System.Text;

namespace Playlist;

public class PlaylistModel
{
    private readonly string _filepath;
    private List<TrackModel> _tracks;
    public string Title { get; }

    public PlaylistModel(string title, string filename)
    {
        Title = title;
        _filepath = Path.Combine(Directory.GetCurrentDirectory(), "Data", filename);
        _tracks = new();
    }

    public void Load()
    {
        if (!File.Exists(_filepath))
        {
            return;
        }

        string[] lines = File.ReadAllLines(_filepath);

        foreach (string line in lines)
        {
            string[] vals = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
            TrackModel? track = ParseTrack(vals);

            if (track != null)
            {
                _tracks.Add(track);
            }
        }
    }

    public void Save()
    {
        File.WriteAllLines(_filepath, _tracks.Select(x => x.ExportString), Encoding.UTF8);
    }

    public void Enqueue(string?[] vals)
    {
        TrackModel? track = ParseTrack(vals);

        if (track != null)
        {
            _tracks.Add(track);
        }
    }

    public void Remove(string? trackName)
    {
        TrackModel? track = _tracks.First(x => x.Title == trackName);

        if (track != null && _tracks.Contains(track))
        {
            _ = _tracks.Remove(track);
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _tracks.Count)
        {
            return;
        }

        _tracks.RemoveAt(index);
    }

    public string View()
    {
        StringBuilder sb = new($"{Title}\n");

        for (int i = 0; i < _tracks.Count; i++)
        {
            sb.AppendLine($"{i + 1}) {_tracks[i]}");
        }

        return sb.ToString();
    }

    public void Shuffle()
    {
        TrackModel[] arr = _tracks.ToArray();
        Random.Shared.Shuffle(arr);
        _tracks = arr.ToList();
    }

    public string GetNumberOfTracks()
    {
        return $"This playlist has {_tracks.Count} tracks";
    }

    public string GetDuration()
    {
        TimeSpan total = new();
        foreach (TrackModel track in _tracks)
        {
            total += track.Duration;
        }

        return $"Total duration of this playlist is {total:c}";
    }

    public void Reset()
    {
        _tracks.Clear();
    }

    public string IsEmpty()
    {
        return $"Playlist is {(_tracks.Count == 0 ? "empty" : "not empty")}";
    }

    private static TrackModel? ParseTrack(string?[] vals)
    {
        if (vals.Length != 3 || !int.TryParse(vals[2], out int duration) || vals.Any(x => x == null))
        {
            return null;
        }

        return new TrackModel(vals[0] ?? "Error", vals[1] ?? "Error", TimeSpan.FromSeconds(duration));
    }
}