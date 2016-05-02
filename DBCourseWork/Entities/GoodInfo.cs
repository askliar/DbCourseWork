using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.GoodInfo")]
    public class GoodInfo
    {
        [Key]
        [Column("Unit Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Unit_Id { get; set; }

        [Column("Unit Quantity")]
        public int? Unit_Quantity { get; set; }
    }
}