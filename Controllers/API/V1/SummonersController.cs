using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace LeagueClient.Controllers.API.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SummonersController : ControllerBase
    {
        static string API_KEY = "RGAPI-95575ba7-262c-4282-97c7-c8a4b4212b00";
        // GET api/v1/Summoners
        [HttpGet]
        public async Task<string> GetSummoner(string region, string name)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{name}?api_key={API_KEY}");
            response.EnsureSuccessStatusCode();
            String result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}