using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork
{
    [Table("Sklyar_A.GoodInfo")]
    public class GoodInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdGoods { get; set; }

        public int? Quantity { get; set; }

        [Key]
        [Column(Order = 1)]
        public double Price { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string GoodName { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Author { get; set; }

        [StringLength(12)]
        public string ISBN { get; set; }

        public int? Year { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ContrName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(15)]
        public string Phone { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Address { get; set; }
    }
}
