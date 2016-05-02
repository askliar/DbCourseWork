using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.GoodsMoves")]
    public class GoodsMove
    {
        [Key]
        public int IdMove { get; set; }

        public int IdGoods { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(15)]
        public string MoveType { get; set; }

        public int IdDoc { get; set; }

        public virtual Documentation Documentation { get; set; }

        public virtual Good Good { get; set; }
    }
}