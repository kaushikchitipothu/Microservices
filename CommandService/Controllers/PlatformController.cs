using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase{

        public PlatformController(){

        }
        
        [HttpPost]
        public ActionResult TestConnection(){

            Console.WriteLine("--> Connection Sucessfull");
            return Ok();
        }
    }
}