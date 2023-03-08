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
        public IActionResult GetLostRobotsForASurface([FromQuery] int surfaceId)
        {
            var lostRobots = LostRobotsService.GetLostRobotsOfSurface(surfaceId);

            return Ok(lostRobots);
        }

        [HttpPost]
        [Route("AddLostRobot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLostRobot([FromBody] LostRobot lostRobot)
        {
            (bool added, string error) = LostRobotsService.AddLostRobot(lostRobot);

            return added ? Ok() : BadRequest(error);
        }
    }
}

