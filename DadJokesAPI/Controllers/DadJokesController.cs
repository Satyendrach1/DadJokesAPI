using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DadJokesAPI.Interface;
using Microsoft.Extensions.Logging;
using DadJokesAPI.Models;
namespace DadJokesAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DadJokesController : ControllerBase
    {
        private IDadJokesService _dadJokesService;
        public DadJokesController(IDadJokesService dadJokesService)
        {
            _dadJokesService = dadJokesService;
        }
        [HttpGet]
        public Task<ActionResult<DadJokeResponse>> GetRandomJokeAsync()
        {
            return _dadJokesService.GetRandomJokeAsync();
        }
        [HttpGet]
        public Task<ActionResult<string>> GetJokeCount()
        {
            return _dadJokesService.GetJokeCount();
        }
    }
}
