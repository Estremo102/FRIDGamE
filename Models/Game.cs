using Microsoft.AspNetCore.Mvc;

namespace FRIDGamE.Models
{
    public class Game
    {
        [HiddenInput]
        public int Id { get; set; }
        public string GameName { get; set; }
        public Developer Studio { get; set; }
        public Publisher GamePublisher { get; set; }

        public decimal RegularPrice { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
