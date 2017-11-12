using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using directoryApi.Models;
using System.Linq;

namespace DirectoryApi.Controllers
{
    [Route("api/[controller]")]
    public class DirectoryController : Controller
    {
        private readonly DirectoryContext _context;

        public DirectoryController(DirectoryContext context)
        {
            _context = context;

            if (_context.DirectoryItems.Count() == 0)
            {
                _context.DirectoryItems.Add(new DirectoryItem { Title = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET /api/directory
        [HttpGet]
        public IEnumerable<DirectoryItem> GetAll()
        {
            return _context.DirectoryItems.ToList();
        }

        // GET /api/directory{id}
        [HttpGet("{id}", Name = "GetDirectory")]
        public IActionResult GetById(long id)
        {
            var item = _context.DirectoryItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DirectoryItem item)
        {
            if (item == null) {
                return BadRequest();
            }
            _context.DirectoryItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetDirectory", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] DirectoryItem item)
        {
            if (item == null || item.Id != id) {
                return BadRequest();
            }

            var directory = _context.DirectoryItems.FirstOrDefault(t => t.Id == id);
            if(directory == null) {
                return NotFound();
            }

            directory.Title = item.Title;
            directory.FirstName = item.FirstName;
            directory.LastName = item.LastName;
            directory.EmailAddress = item.EmailAddress;
            directory.Phone = item.Phone;
            directory.WebSite = item.WebSite;
            directory.isPrivate = item.isPrivate;

            _context.DirectoryItems.Update(directory);
            _context.SaveChanges();
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var directory = _context.DirectoryItems.FirstOrDefault(t => t.Id == id);
            if(directory == null) {
                return NotFound();
            }

            _context.DirectoryItems.Remove(directory);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}