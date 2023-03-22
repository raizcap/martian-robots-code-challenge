using MartianRobotsApp.Models;

namespace MartianRobotsApp.Communication
{
    public interface ISurfacesConnector
    {
        Task<Surface?> GetSurfaceBySize(int XSize, int YSize);

        Task<Surface?> AddSurface(int XSize, int YSize);
    }
}