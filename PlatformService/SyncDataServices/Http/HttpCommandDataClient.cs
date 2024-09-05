using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.HTTP{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration){
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(ReadPlatformDto readPlatformDto)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(readPlatformDto),
                Encoding.UTF8,
                "application/json"
            );

            var httpResponse = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

            if(httpResponse.IsSuccessStatusCode){
                Console.WriteLine("-->sync post to command service about platform");
            }
            else{
                Console.WriteLine("sync post to command service about platform failed");
            }
        }
    }
}