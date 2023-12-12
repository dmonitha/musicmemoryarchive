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
}
