using FRIDGamE.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace FRIDGamE.Models
{
    public class Game
    {
        [HiddenInput]
        public int Id { get; set; }
        public string GameName { get; set; }
        public Developer Studio { get; set; }
        public int StudioId { get; set; }
        public Publisher GamePublisher { get; set; }
        public int GamePublisherId { get; set; }
        public string Description { get; set; }

        public decimal RegularPrice { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ISet<FRIDGamEUser> Owners { get; set; }
    }
}
