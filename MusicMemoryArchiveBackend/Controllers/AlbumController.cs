using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMADatabase;
using MusicMemoryArchiveBackend.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicMemoryArchiveBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly MusicMemoryArchiveContext _db;
        public AlbumController(MusicMemoryArchiveContext db)
        {
            _db = db;
        }

        // GET: api/<AlbumController>
        [HttpGet]
        [Authorize]
        public IEnumerable<Album> Get()
        {
            return _db.Albums.ToList();
        }


        [HttpGet("Album/{id}")]
        public AlbumDTO? GetSongs(int id)
        {
           
            return
               
                (from album in _db.Albums
                 where album.Id == id
                 select new AlbumDTO()
                 {
                     Name = album.Name,
                     Artist = album.Artist
                    // ListOfSongs =  
                 }).SingleOrDefault();
        }
        // GET api/<AlbumController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlbumController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlbumController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlbumController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
