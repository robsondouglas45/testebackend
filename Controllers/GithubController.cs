using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using robsonteste.Models;

namespace robsonteste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {       

        IHttpClientFactory _clientFactory;

        public GithubController(IHttpClientFactory clientFactory)
        {          
            _clientFactory = clientFactory;
        }       

        [HttpGet("users")]
        public async Task<IActionResult> Usuario(string user = "dotnet")
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("http://api.github.com/users/");
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            var result = await client.GetStreamAsync(user);           
            var response = JsonSerializer.DeserializeAsync<UserModel>(result);                      
            return Ok(response);
        }

        [HttpGet("repositorys")]
        public async Task<IActionResult> Repository(string user = "dotnet")
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.github.com/users/"); 
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            var result = await client.GetStreamAsync(user + "/repos");          
            return Ok(result);
        }
    }
}
