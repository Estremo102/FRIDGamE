using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FRIDGamE.Models
{
    [Table("Publishers")]
    public class Publisher
    {
        public Publisher()
        {
            games = new HashSet<Game>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("publisher_name")]
        [StringLength(30)]
        public string PublisherName { get; set; }
        [Column("nip")]
        [StringLength(10)]
        [MaxLength(10)]
        [MinLength(10)]
        public string NIP { get; set; }
        public ISet<Game> games { get; set; }
    }
}
