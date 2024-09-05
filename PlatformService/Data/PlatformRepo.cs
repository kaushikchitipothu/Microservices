using PlatformService.Models;

namespace PlatformService.Data{
    class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context){
            _context = context;
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat == null){
                throw new ArgumentNullException(nameof(plat));
            }
            _context.Platforms.Add(plat);
            _context.SaveChanges();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformByID(int id)
        {
            return  _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}