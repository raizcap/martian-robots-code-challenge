using System;
using DB;

namespace API.Services
{
	public interface ISurfacesService
	{
		IEnumerable<Surface> GetAllSurfaces();

		IEnumerable<Surface> GetSurfaceOfSize(int xSize, int ySize);
	}
}

