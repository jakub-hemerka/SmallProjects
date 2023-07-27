using Playlist;

PlaylistModel playlist = new PlaylistModel("Epický playlist všeho druhu", "epic_playlist.csv");
playlist.Load();
playlist.View();