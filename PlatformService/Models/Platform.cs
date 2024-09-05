using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models{
    public class Platform{

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Publisher { get; set; }

        [Required]
        public String Cost { get; set; }
    }
}