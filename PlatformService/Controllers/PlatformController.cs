using System.Windows.Input;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.HTTP;

namespace PlatformService.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController: ControllerBase{
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformController(IPlatformRepo platformRepo, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadPlatformDto>> GetPlatforms(){
            Console.WriteLine("---> Getting platforms....");
           var platforms =  _platformRepo.GetAllPlatforms();
           return Ok(_mapper.Map<IEnumerable<ReadPlatformDto>>(platforms));
        }
        [HttpGet("{id}",Name="GetPlatformById")]
        public ActionResult<ReadPlatformDto> GetPlatformById(int id){
            var platform = _platformRepo.GetPlatformByID(id);
            if(platform == null){
                return NotFound();
            }
            else{
                return Ok(_mapper.Map<ReadPlatformDto>(platform));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReadPlatformDto>> CreatePlatform(CreatePlatformDto createPlatformDto){
            var plat = _mapper.Map<Platform>(createPlatformDto);
            _platformRepo.CreatePlatform(plat);
            _platformRepo.saveChanges();
            
            var platformRead = _mapper.Map<ReadPlatformDto>(plat);

            try{
                await _commandDataClient.SendPlatformToCommand(platformRead);
            }
            catch(Exception ex){
                Console.WriteLine($"Unable to send platform synchronusly : {ex.Message}");
            }
            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platformRead.Id}, platformRead);
        } 
    }
}