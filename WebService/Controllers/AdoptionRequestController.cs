using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class AdoptionRequestController : ControllerBase
    {
        private readonly ILogger<AnimalSubmissionsController> _logger;
        private readonly IAdoptionRequestRepository _context;

        public AdoptionRequestController(ILogger<AnimalSubmissionsController> logger, IAdoptionRequestRepository adoptionRequestRepository)
        {
            _logger = logger;
            _context = adoptionRequestRepository;
        }

        // GET: api/<AdoptionRequestController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.GetAll());
        }

        // GET api/<AdoptionRequestController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _context.Get(id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        // POST api/<AdoptionRequestController>
        [HttpPost]
        public IActionResult Post([FromBody] AdoptionRequest adoptionRequest)
        {
            if (ModelState.IsValid)
            {
                adoptionRequest.Id = 0;
                _context.Add(adoptionRequest);
                return Ok(ModelState);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<AdoptionRequestController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdoptionRequest adoptionRequest)
        {
            if (ModelState.IsValid)
            {
                adoptionRequest.Id = id;
                _context.Update(adoptionRequest);
                return Ok(ModelState);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
