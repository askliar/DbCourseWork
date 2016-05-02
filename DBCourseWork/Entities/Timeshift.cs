using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.Timeshift")]
    public class Timeshift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTmshift { get; set; }

        [Column(TypeName = "date")]
        public DateTime WorkDate { get; set; }

        public TimeSpan TimeIn { get; set; }

        public TimeSpan TimeOut { get; set; }

        [Required]
        [StringLength(15)]
        public string TypeShift { get; set; }

        public int IdStuff { get; set; }

        public virtual Stuff Stuff { get; set; }
    }
}