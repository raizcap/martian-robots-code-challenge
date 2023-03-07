using System;
using API.Services;
using DB;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LostRobotsController : ControllerBase
	{
        private readonly ILostRobotsService LostRobotsService;

		public LostRobotsController(ILostRobotsService lostRobotsService)
		{
            LostRobotsService = lostRobotsService;
		}

        [HttpGet]
        [Route("GetAllLostRobots")]
        [ProducesResponseType(typeof(IEnumerable<LostRobot>), StatusCodes.Status200OK)]
        public IActionResult GetAllLostRobots()
        {
            var lostRobots = LostRobotsService.GetAllLostRobots();

            return Ok(lostRobots);
        }

        [HttpGet]
        [Route("LostRobotsForASurface")]
        [ProducesResponseType(typeof(IEnumerable<LostRobot>), StatusCodes.Status200OK)]
        public IActionResult GetLostRobotsForASurface([FromQuery] int x, [FromQuery] int y)
        {
            var lostRobots = LostRobotsService.GetLostRobotsOfSurface(x, y);

            return Ok(lostRobots);
        }
    }
}

