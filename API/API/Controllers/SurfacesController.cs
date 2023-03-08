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
        [ProducesResponseType(typeof(IEnumerable<Surface>), StatusCodes.Status200OK)]
        public IActionResult GetAllSurfaces()
        {
            var surfaces = SurfacesService.GetAllSurfaces();

            return Ok(surfaces);
        }

        [HttpGet]
        [Route("GetSurfaceBySize")]
        [ProducesResponseType(typeof(Surface), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetSurfaceBySize([FromQuery] int xSize, [FromQuery] int ySize)
        {
            var surface = SurfacesService.GetSurfaceBySize(xSize, ySize);

            return Ok(surface);
        }

        [HttpPost]
        [Route("AddSurface")]
        [ProducesResponseType(typeof(Surface), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Surface), StatusCodes.Status400BadRequest)]
        public IActionResult AddSurface([FromQuery] int xSize, [FromQuery] int ySize)
        {
            if (xSize < 0 || xSize > 50)
            {
                return BadRequest($"The surface size x={xSize} is not valid");
            }

            if (ySize < 0 || ySize > 50)
            {
                return BadRequest($"The surface size y={ySize} is not valid");
            }

            var surface = SurfacesService.AddSurface(xSize, ySize);

            return Ok(surface);
        }
    }
}

