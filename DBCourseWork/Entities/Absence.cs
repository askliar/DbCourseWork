using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.Absences")]
    public class Absence
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Absence()
        {
            Stuffs = new HashSet<Stuff>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAbsence { get; set; }

        public int IdStuff { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOut { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        public int IdAbsType { get; set; }

        public virtual AbsenceType AbsenceType { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stuff> Stuffs { get; set; }
    }
}