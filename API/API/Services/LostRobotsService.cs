using System;
using DB;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class LostRobotsService : ILostRobotsService
    {
        private readonly IServiceScopeFactory mScopeFactory;
        private readonly ISurfacesService mSurfacesService;
        private readonly CodeChallengeContext mDbContext;

        public LostRobotsService(ISurfacesService surfacesService, IServiceScopeFactory scopeFactory)
        {
            mScopeFactory = scopeFactory;
            mSurfacesService = surfacesService;

            var scope = mScopeFactory.CreateScope();
            mDbContext = scope.ServiceProvider.GetRequiredService<CodeChallengeContext>();
        }

        public IEnumerable<LostRobot> GetAllLostRobots()
        {
            return mDbContext.LostRobots.AsEnumerable();
        }

        public IEnumerable<LostRobot> GetLostRobotsOfSurface(int surfaceId)
        {
            return mDbContext.LostRobots.Where(robot => robot.surface.surfaceId == surfaceId);
        }

        public (bool, string) AddLostRobot(LostRobot lostRobot)
        {
            var surface = mSurfacesService.GetSurfaceById(lostRobot.surfaceId);
            if (surface == null)
            {
                return (false, $"Surface {lostRobot.surfaceId} doesn't exist");
            }

            // A lost robot should not be inserted twice for a surface,
            // but just in case I check it here
            var alreadyLostRobot = surface.LostRobots.Any(
                robot =>
                    robot.xCoordinate == lostRobot.xCoordinate
                    && robot.yCoordinate == lostRobot.yCoordinate
                    && robot.orientation.Equals(lostRobot.orientation)
                );

            if (!alreadyLostRobot)
            {
                surface.LostRobots.Add(lostRobot);
                mDbContext.Surfaces.Update(surface);
                mDbContext.SaveChanges();

                return (true, "");
            }

            return (false, "Robot already lost previously " +
                $"in x={lostRobot.xCoordinate} y={lostRobot.yCoordinate} " +
                $"for surface {lostRobot.surfaceId}");
        }
    }
}

