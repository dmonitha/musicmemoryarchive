using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Post([FromBody] Song newSongData)
        {
            var newSong = new Song
            {
                SongName = newSongData.SongName,
                Duration = newSongData.Duration,
                AlbumId = newSongData.AlbumId,
                Rating = newSongData.Rating,
                FeaturingArtist = newSongData.FeaturingArtist


            };
            _db.Songs.Add(newSong) ;
            int affectedRecords = _db.SaveChanges();

            if (affectedRecords > 0)
            {
                return Ok("Song added successfully");
            }
            else
            {
                return StatusCode(500, "Failed to add the song to the database");
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
