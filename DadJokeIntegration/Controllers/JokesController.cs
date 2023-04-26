using DadJokeIntegration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace DadJokeIntegration.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly HTTpService hTTpService;
        public JokesController(IConfiguration configuration, HTTpService hTTpService)
        {
            this.configuration = configuration;
            this.hTTpService = hTTpService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomJoke()
        {

            var res= hTTpService.GetData("random/joke", "", "", "");
            var Dres = JsonConvert.DeserializeObject<JokeResponse>(res);
            if(Dres == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(Dres);
        }

        [HttpGet]
        public async Task<IActionResult> GetJokeCount()
        {

            var res = hTTpService.GetData("joke/count", "", "", "");
            var Dres=JsonConvert.DeserializeObject<DadJokeCountResponse>(res);
            if(Dres == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(Dres.Body);
        }
    }
}
