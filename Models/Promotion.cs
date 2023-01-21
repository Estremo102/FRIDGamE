using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FRIDGamE.Models
{
    [Table("Promotions")]
    public class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę gry!")]
        public Game GameName { get; set; }
        public int GameNameId { get; set; }
        public decimal RegularPrice { get; set; }
        [Range(1, 100, ErrorMessage = "Promocja musi wynosić pomiędzy 1% a 100%")]
        public int Discount { get; set; }
        [Required(ErrorMessage = "Proszę określić do kiedy trwa promocja!")]
        [DataType(DataType.Date)]
        public DateTime EndOfPromotion { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartOfPromotion { get; }
    }
}
