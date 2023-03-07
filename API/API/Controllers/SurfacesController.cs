using System;
using API.Services;
using DB;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
	public class SurfacesController : ControllerBase
    {
        private readonly ISurfacesService SurfacesService;

        public SurfacesController(ISurfacesService surfacesService)
		{
            SurfacesService = surfacesService;
		}

        [HttpGet]
        [Route("GetAllSurfaces")]
        [ProducesResponseType(typeof(IEnumerable<LostRobot>), StatusCodes.Status200OK)]
        public IActionResult GetAllSurfaces()
        {
            var surfaces = SurfacesService.GetAllSurfaces();

            return Ok(surfaces);
        }

        [HttpGet]
        [Route("GetSurfaceOfSize")]
        [ProducesResponseType(typeof(IEnumerable<LostRobot>), StatusCodes.Status200OK)]
        public IActionResult GetSurfaceOfSize([FromQuery] int xSize, [FromQuery] int ySize)
        {
            var surface = SurfacesService.GetSurfaceOfSize(xSize, ySize);

            return Ok(surface);
        }
    }
}

