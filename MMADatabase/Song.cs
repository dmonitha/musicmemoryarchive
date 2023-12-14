using System;
using System.Collections.Generic;

namespace MMADatabase;

public partial class Song
{
    public int Id { get; set; }

    public string SongName { get; set; } = null!;

    public int Duration { get; set; }

    public int AlbumId { get; set; }

    public string? FeaturingArtist { get; set; }

    public int Rating { get; set; }

    public virtual Album? Album { get; set; } = null!;
}
