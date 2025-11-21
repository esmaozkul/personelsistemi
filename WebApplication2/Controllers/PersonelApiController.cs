using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebShared.CO;
using WebShared.DTO;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public PersonelController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("Liste")]
        public async Task<ActionResult<PersonelListeDTO[]>> Liste([FromBody] PersonelListeCO kriter)
        {
            // MVC1 URL'si
            var mvc1Url = "https://localhost:7090/Home/PersonelListeGetir";


            var response = await _httpClient.PostAsJsonAsync(mvc1Url, kriter);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "API çağrısı başarısız");
            }

            var liste = await response.Content.ReadFromJsonAsync<PersonelListeDTO[]>();
            return Ok(liste); // Angular için JSON döndür
        }
    }
}
