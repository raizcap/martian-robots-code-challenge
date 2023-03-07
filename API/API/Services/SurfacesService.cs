using System;
using DB;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
	public class SurfacesService : ISurfacesService
	{
        private readonly IServiceScopeFactory ScopeFactory;

        public SurfacesService(IServiceScopeFactory scopeFactory)
		{
            ScopeFactory = scopeFactory;
        }

        public IEnumerable<Surface> GetAllSurfaces()
        {
            var scope = ScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CodeChallengeContext>();

            return dbContext.Surfaces.Include(s => s.LostRobots).AsEnumerable();
        }

        public IEnumerable<Surface> GetSurfaceOfSize(int xSize, int ySize)
        {
            var scope = ScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CodeChallengeContext>();

            return dbContext.Surfaces.Include(s => s.LostRobots)
                                     .Where(surface => surface.xSize == xSize && surface.ySize == ySize);
        }
    }
}

