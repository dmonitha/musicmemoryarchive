using System;
using System.Collections.Generic;

namespace MMADatabase;

public partial class Album
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NumberOfSongs { get; set; }

    public string Artist { get; set; } = null!;

    public int YearOfRelease { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();

    public Album() { }
    public Album(Album album) {
        this.Id = album.Id;
        this.Name = album.Name;
        this.Artist = album.Artist;
        this.NumberOfSongs = album.NumberOfSongs;
        this.YearOfRelease = album.YearOfRelease;
    }  
}
