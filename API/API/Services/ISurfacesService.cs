using System;
using DB;

namespace API.Services
{
	public interface ISurfacesService
	{
		IEnumerable<Surface> GetAllSurfaces();

		Surface? GetSurfaceBySize(int xSize, int ySize);

		Surface? GetSurfaceById(int surfaceId);

		Surface AddSurface(int xSize, int ySize);
	}
}

