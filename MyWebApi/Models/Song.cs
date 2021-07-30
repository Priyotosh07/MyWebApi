using System;
using System.Collections.Generic;

#nullable disable

namespace MyWebApi.Models
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Songname { get; set; }
        public string SongAuthor { get; set; }
        public string SongGenre { get; set; }
        public DateTime SongRelaeaseDate { get; set; }
    }
}
