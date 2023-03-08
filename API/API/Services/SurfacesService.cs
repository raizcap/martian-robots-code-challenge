using System;
using DB;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
	public class SurfacesService : ISurfacesService
	{
        private readonly IServiceScopeFactory mScopeFactory;
        private readonly CodeChallengeContext mDbContext;

        public SurfacesService(IServiceScopeFactory scopeFactory)
		{
            mScopeFactory = scopeFactory;

            var scope = mScopeFactory.CreateScope();
            mDbContext = scope.ServiceProvider.GetRequiredService<CodeChallengeContext>();
        }

        public IEnumerable<Surface> GetAllSurfaces()
        {
            return mDbContext.Surfaces.Include(s => s.LostRobots).AsEnumerable();
        }

        public Surface? GetSurfaceBySize(int xSize, int ySize)
        {
            return mDbContext.Surfaces.Include(s => s.LostRobots)
                .FirstOrDefault<Surface>(surface => surface.xSize == xSize && surface.ySize == ySize);
        }

        public Surface? GetSurfaceById(int surfaceId)
        {
            return mDbContext.Surfaces.FirstOrDefault(surface => surface.surfaceId == surfaceId);
        }

        public Surface AddSurface(int xSize, int ySize)
        {
            var surface = GetSurfaceBySize(xSize, ySize);

            if (surface != null)
            {
                return surface;
            }

            surface = new Surface()
            {
                xSize = xSize,
                ySize = ySize
            };

            var addedSurface = mDbContext.Add<Surface>(surface);
            mDbContext.SaveChanges();

            return addedSurface.Entity;
        }
    }
}

