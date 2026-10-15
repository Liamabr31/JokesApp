using System.ComponentModel.DataAnnotations;

namespace JokesApp.Models
{
    public class Joke
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Joke Question")]
        public string JokeQuestion { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Joke Answer")]
        public string JokeAnswer { get; set; } = string.Empty;
    }
}
