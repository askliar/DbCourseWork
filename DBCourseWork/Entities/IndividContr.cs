using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.IndividContr")]
    public class IndividContr
    {
        [Key]
        public int IdInd { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public int IdContr { get; set; }

        public virtual Contractor Contractor { get; set; }
    }
}