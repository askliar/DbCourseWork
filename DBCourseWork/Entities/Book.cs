using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.Books")]
    public class Book
    {
        [Key]
        public int IdBook { get; set; }

        [Required]
        [StringLength(30)]
        public string Author { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Year { get; set; }

        [Required]
        [StringLength(12)]
        public string ISBN { get; set; }

        public int IdGoods { get; set; }

        public virtual Good Good { get; set; }
    }
}