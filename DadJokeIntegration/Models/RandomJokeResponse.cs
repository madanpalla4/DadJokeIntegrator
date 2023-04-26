namespace DadJokeIntegration.Models
{

    public class JokeResponse
    {
        public bool Success { get; set; }
        public List<Joke> Body { get; set; }
    }
    public class Joke
    {
        public string setup { get; set; }
        public string Punchline { get; set; }
    }
}
