using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ILogger<AnimalsController> _logger;
        private readonly IAnimalRepository _context;

        public AnimalsController(ILogger<AnimalsController> logger, IAnimalRepository animalRepository)
        {
            _logger = logger;
            _context = animalRepository;
        }

        // GET: api/<AnimalsController>
        [HttpGet]
        public IActionResult Get([FromQuery]string dogOrCat, [FromQuery]string gender, [FromQuery]string safeForKids)
        {
            var result = _context.GetAll();
            //Check of er query params zijn en filtreer op deze.
            if (dogOrCat != null) result = result.Where(a => a.DogOrCat == dogOrCat);
            if (gender != null) result = result.Where(a => a.Gender == gender);
            if (safeForKids != null && safeForKids.ToLower().Equals("true") || safeForKids.ToLower().Equals("false") ) result = result.Where(a => a.SafeForKids == Boolean.Parse(safeForKids));
            return Ok(result);
        }

        // GET api/<AnimalsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animal = _context.Get(id);
            if (animal != null) return Ok(animal);
            return NotFound();
        }
    }
}
