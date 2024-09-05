using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos{
    public class CreatePlatformDto{
        [Required]
        public String Name { get; set; }

        [Required]
        public String Publisher { get; set; }

        [Required]
        public String Cost { get; set; }
    }
}