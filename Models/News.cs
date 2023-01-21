using FRIDGamE.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FRIDGamE.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
        public string Headline { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public FRIDGamEUser? Author { get; set; }
    }
}
