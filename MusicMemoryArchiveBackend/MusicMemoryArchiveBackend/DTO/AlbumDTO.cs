namespace MusicMemoryArchiveBackend.DTO
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Artist { get; set; }

        public IEnumerable<string> ListOfSongNames { get; set; }
       

    }
}
