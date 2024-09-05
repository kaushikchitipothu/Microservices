using Microsoft.EntityFrameworkCore;

namespace PlatformService.Models{
   public class  AppDbContext :DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }

        public DbSet<Platform> Platforms { get; set; }
    }
}