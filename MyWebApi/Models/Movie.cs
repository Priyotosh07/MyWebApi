using System;
using System.Collections.Generic;

#nullable disable

namespace MyWebApi.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
        public string CoverPhoto { get; set; }
        public bool? IsPrivate { get; set; }
    }
}
