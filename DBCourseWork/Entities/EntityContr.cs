using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.EntityContr")]
    public class EntityContr
    {
        [Key]
        public int IdEnt { get; set; }

        [Required]
        [StringLength(15)]
        public string StateNumber { get; set; }

        public int IdContr { get; set; }

        public virtual Contractor Contractor { get; set; }
    }
}