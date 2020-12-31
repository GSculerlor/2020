using System;
using Newtonsoft.Json;

namespace Project2020.Game.Models
{
    [Serializable]
    public class TrackSong
    {
        [JsonProperty(@"id")]
        public int Id;

        [JsonProperty(@"song_name")]
        public string SongName;

        [JsonProperty(@"song_artist")]
        public string SongArtist;

        [JsonProperty(@"song_album")]
        public string SongAlbum;

        [JsonProperty(@"album_path")]
        public string AlbumPath;

        [JsonProperty(@"track_dir")]
        public string TrackDir;
    }
}