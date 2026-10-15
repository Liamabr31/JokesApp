using JokesApp.Models;

namespace JokesApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Joke.Any())
            {
                return;
            }

            var jokes = new Joke[]
            {
                new Joke
                {
                    JokeQuestion = "Why did the chicken cross the road?",
                    JokeAnswer = "To get to the other side."
                },
                new Joke
                {
                    JokeQuestion = "Why was the computer cold?",
                    JokeAnswer = "It left its Windows open."
                },
                new Joke
                {
                    JokeQuestion = "What do you call a fake noodle?",
                    JokeAnswer = "An impasta."
                }
            };

            context.Joke.AddRange(jokes);
            context.SaveChanges();
        }
    }
}
