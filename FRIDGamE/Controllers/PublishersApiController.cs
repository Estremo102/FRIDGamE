using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FRIDGamE.Areas.Identity.Data;
using FRIDGamE.Models;

namespace FRIDGamE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersApiController : ControllerBase
    {
        //private readonly IdentityContext _context;
        private readonly IPublisherService _publisherService;

        //public PublishersApiController(IdentityContext context)
        //{
        //    _context = context;
        //}

        public PublishersApiController(IPublisherService service)
        {
            _publisherService = service;
        }

        // GET: api/PublishersApi
        [HttpGet]
        public IEnumerable<Publisher> GetPublishers() => _publisherService.FindAll();

        // GET: api/PublishersApi/5
        [HttpGet("{id}")]
        public ActionResult<Publisher> GetPublisher(int id)
        {
            var publisher = _publisherService.FindById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return publisher;
        }

        // PUT: api/PublishersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Publisher> PutPublisher([FromBody]Publisher publisher)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(_publisherService.Update(publisher))
            {
                return Ok(publisher);
            }
            return NotFound();
        }

        // POST: api/PublishersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Publisher> PostPublisher(Publisher publisher)
        { 
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _publisherService.Save(publisher);
            return Created($"/api/PublishersApi/{publisher.Id}", publisher);
        }

        // DELETE: api/PublishersApi/5
        [HttpDelete("{id}")]
        public ActionResult<Publisher> DeletePublisher(int id)
        {
            var publisher = _publisherService.FindById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            if(_publisherService.Delete(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        private bool PublisherExists(int id) => _publisherService.FindById(id) != null;
    }
}
