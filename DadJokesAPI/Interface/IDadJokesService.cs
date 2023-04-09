using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadJokesAPI.Interface
{
     public interface IDadJokesService
    {
        public Task<ActionResult<string>> GetRandomJokeAsync();
        public  Task<ActionResult<string>> GetJokeCount();
    }
}
