using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRIDGamE.Models
{
    [Table("Developers")]
    public class Developer
    {
        public Developer()
        {
            games = new HashSet<Game>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("developer_name")]
        [StringLength(30)]
        public string DeveloperName { get; set; }
        [Column("nip")]
        [StringLength(10)]
        public string NIP { get; set; }
        public ISet<Game> games { get; set; }
    }
}
