using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadJokesAPI.Models;

namespace DadJokesAPI.Interface
{
    /// <summary>
    /// Interface for DadJokesService
    /// </summary>
    public interface IDadJokesService
    {
        public Task<ActionResult<DadJokeResponse>> GetRandomJokeAsync();
        public  Task<ActionResult<string>> GetJokeCount();
    }
}
