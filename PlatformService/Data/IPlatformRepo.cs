using PlatformService.Models;

namespace PlatformService.Data{
    public interface IPlatformRepo{
           bool saveChanges();

           IEnumerable<Platform> GetAllPlatforms();
           Platform GetPlatformByID(int id);
           void CreatePlatform(Platform plat);
    }
}