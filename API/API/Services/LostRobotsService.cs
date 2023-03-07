using System;
using DB;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class LostRobotsService : ILostRobotsService
    {
        private readonly IServiceScopeFactory ScopeFactory;

        public LostRobotsService(IServiceScopeFactory scopeFactory)
        {
            ScopeFactory = scopeFactory;
        }

        public IEnumerable<LostRobot> GetAllLostRobots()
        {
            var scope = ScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CodeChallengeContext>();

            return dbContext.LostRobots.AsEnumerable();
        }

        public IEnumerable<LostRobot> GetLostRobotsOfSurface(int x, int y)
        {
            var scope = ScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CodeChallengeContext>();

            return dbContext.LostRobots.Where(robot => robot.surface.xSize == x && robot.surface.ySize == y);
        }
    }
}

