using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DadJokesAPI.Models
{
    public class DadJokeResponse
    {
        public bool success { get; set; } 
        public List<Body> body { get; set; }
    }
    public class Body
    {
        public string _id { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
    }
}