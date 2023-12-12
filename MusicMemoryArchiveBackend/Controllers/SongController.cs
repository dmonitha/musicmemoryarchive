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
        public IEnumerable<Song> Get()
        {
            return _db.Songs.ToList();
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SongController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
