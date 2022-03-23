using Microsoft.AspNetCore.Mvc;
using RestAPI.Domain;
using RestAPI.Services;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevelopersController : ControllerBase
    {

        //Dependency inject the service into the controller
        protected readonly IDeveloperService _developerService;
        // Dependency injection. Now we have access to all the methods we need
        public DevelopersController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDevelopers()
        {
            var developers = await _developerService.GetAllDevelopers();
            return Ok(developers);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDeveloperById(int Id)
        {
            var developers = await _developerService.GetDeveloperById(Id);
            return Ok(developers);
        }

        [HttpGet("{Email}")]
        public async Task<IActionResult> GetDeveloperByEmail(string DeveloperEmail)
        {
            var developers = await _developerService.GetDeveloperByEmail(DeveloperEmail);
            return Ok(developers);
        }

        [HttpPost]
        public IActionResult AddDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             _developerService.AddDeveloper(developer);
            return CreatedAtAction(nameof(GetDeveloperById), new { Id = developer.Id }, developer);
        }


        [HttpPut]
        public IActionResult UpdateDeveloper([FromBody] Developer developer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _developerService.UpdateDeveloper(developer);
            return Ok();
        }


        [HttpDelete]
        public IActionResult DeleteDeveloper(int Id)
        {
            _developerService.DeleteDeveloper(Id);
            return Ok();
        
        }









    }
}
