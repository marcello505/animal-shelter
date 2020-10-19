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
    public class AnimalSubmissionsController : ControllerBase
    {
        private readonly ILogger<AnimalSubmissionsController> _logger;
        private readonly IAnimalSubmissionRepository _context;

        public AnimalSubmissionsController(ILogger<AnimalSubmissionsController> logger, IAnimalSubmissionRepository animalSubmissionRepository)
        {
            _logger = logger;
            _context = animalSubmissionRepository;
        }

        // GET: api/<AnimalSubmissionsController>
        [HttpGet]
        public IActionResult Get([FromQuery] string OwnerName)
        {
            var result = _context.GetAll();
            if (OwnerName != null) result = result.Where(ans => ans.OwnerName == OwnerName);
            return Ok(result);
        }

        // GET api/<AnimalSubmissionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _context.Get(id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(AnimalSubmission animalSubmission)
        {
            if (ModelState.IsValid)
            {
                animalSubmission.Id = 0;
                _context.Add(animalSubmission);
                return Ok(ModelState);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/<AnimalSubmissionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnimalSubmission animalSubmission)
        {
            if (ModelState.IsValid)
            {
                animalSubmission.Id = id;
                _context.Update(animalSubmission);
                return Ok(ModelState);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
