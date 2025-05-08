using Playlist;

PlaylistModel playlist = new("Sračky", "pop_music.csv");
string input;
bool exit = false;

while (!exit)
{
    Console.Clear();
    PrintCommands();
    int result = GetNumberFromUser("Which command do you want to execute: ");

    switch (result)
    {
        case 1:
            playlist.Load();
            Console.WriteLine("Playlist has been loaded.");
            break;
        case 2:
            playlist.Save();
            Console.WriteLine("Playlist has been saved.");
            break;
        case 3:
            string?[] arr = new string?[3];
            arr[0] = GetInputFromUser("Enter track's name: ");
            arr[1] = GetInputFromUser("Enter track's author: ");
            arr[2] = GetNumberFromUser("Enter track's duration in seconds: ").ToString();
            playlist.Enqueue(arr);
            break;
        case 4:
            input = GetInputFromUser("Enter the name of the track you wish to remove: ");
            playlist.Remove(input);
            break;
        case 5:
            int index = GetNumberFromUser("Enter the index of the track you wish to remove: ");
            playlist.RemoveAt(index);
            break;
        case 6:
            Console.WriteLine(playlist.View());
            break;
        case 7:
            playlist.Shuffle();
            Console.WriteLine("Playlist has been shuffled");
            break;
        case 8:
            Console.WriteLine(playlist.GetNumberOfTracks());
            break;
        case 9:
            Console.WriteLine(playlist.GetDuration());
            break;
        case 10:
            playlist.Reset();
            break;
        case 11:
            Console.WriteLine(playlist.IsEmpty());
            break;
        case 12:
            exit = true;
            break;
        default:
            break;
    }

    if (exit)
    {
        break;
    }

    Console.Write("Console is about to be cleared. Press any key to continue...");
    Console.ReadKey(false);
}

static int GetNumberFromUser(string message)
{
    while (true)
    {
        if (int.TryParse(GetInputFromUser(message), out int result))
        {
            return result;
        }

        Console.WriteLine("Your input was not in the correct format. Please try again...");
    }
}

static string GetInputFromUser(string message)
{
    Console.Write(message);
    string input = Console.ReadLine() ?? "";

    return input;
}

static void PrintCommands()
{
    Console.WriteLine();
    Console.WriteLine("Available commands:");
    Console.WriteLine("1 - Load the playlist");
    Console.WriteLine("2 - Save the playlist");
    Console.WriteLine("3 - Add new track into the playlist");
    Console.WriteLine("4 - Remove specific track");
    Console.WriteLine("5 - Remove track at specific index");
    Console.WriteLine("6 - View all tracks");
    Console.WriteLine("7 - Shuffle the playlist");
    Console.WriteLine("8 - Get the number of tracks");
    Console.WriteLine("9 - Get the total duration of the playlist");
    Console.WriteLine("10 - Clear the playlist");
    Console.WriteLine("11 - Check if the playlist is empty or not");
    Console.WriteLine("12 - Exit the application");
    Console.WriteLine();
}