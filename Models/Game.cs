using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRIDGamE.Models
{
    public class Game
    {
        public Game()
        {
            Owners = new HashSet<Customer>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę gry!")]
        public string GameName { get; set; }
        public Developer? Studio { get; set; }
        public int StudioId { get; set; }
        public Publisher? GamePublisher { get; set; }
        public int GamePublisherId { get; set; }
        public string Description { get; set; }

        public decimal RegularPrice { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ISet<Customer> Owners { get; set; }
    }
}
