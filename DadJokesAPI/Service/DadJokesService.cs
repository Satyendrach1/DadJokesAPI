using DadJokesAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using DadJokesAPI.Models;

namespace DadJokesAPI.Service
{
    public class DadJokesService : IDadJokesService
    {
        private readonly HttpClient client = new();
        //Injecting HttpClientFactory at constuctor level
        private IHttpClientFactory _httpClient;
        public DadJokesService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            client = _httpClient.CreateClient("dadjokes");
        }
        /// <summary>
        /// Get Randon jokes from the API
        /// </summary>
        /// <returns>Jokes response</returns>
        public async Task<ActionResult<DadJokeResponse>> GetRandomJokeAsync()
        {
            var response = await client.GetAsync("random/joke");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DadJokeResponse>(body);
        }
        /// <summary>
        /// Get jokes Count from the API
        /// </summary>
        /// <returns>Joke Count</returns>
        public async Task<ActionResult<string>> GetJokeCount()
        {
            var response = await client.GetAsync("joke/count");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
