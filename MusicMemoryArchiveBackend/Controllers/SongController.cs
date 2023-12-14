using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMADatabase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicMemoryArchiveBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly MusicMemoryArchiveContext _db;
        public SongController(MusicMemoryArchiveContext db)
        {
            _db = db;
        }
        // GET: api/<SongController>
        [HttpGet]
        [Authorize]
        public IEnumerable<Song> Get()
        {
            return _db.Songs.ToList();
        }


    
        // POST api/<SongController>
        [HttpPost]
        public async Task<String> Post([FromBody] Song newSongData)
        {
            var albumId = newSongData.AlbumId;
            var existingAlbum = _db.Albums.Find(albumId);

            if (existingAlbum != null)
            {
                _db.Entry(existingAlbum).State = EntityState.Unchanged;
            }


            var newSong = new Song
            {
                SongName = newSongData.SongName,
                Duration = newSongData.Duration,
                AlbumId = newSongData.AlbumId,
                Rating = newSongData.Rating,
                FeaturingArtist = newSongData.FeaturingArtist,
                Album = existingAlbum
            };
            _db.Songs.Add(newSong) ;
            int affectedRecords = _db.SaveChanges();

            if (affectedRecords > 0)
            {
                return "Success";
            }
            else
            {
                return "Failed! Please try again with correct values";
            }
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
