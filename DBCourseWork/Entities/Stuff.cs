using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.Stuff")]
    public class Stuff
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stuff()
        {
            Documentations = new HashSet<Documentation>();
            Timeshifts = new HashSet<Timeshift>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdStuff { get; set; }

        public int IdPerson { get; set; }

        public int IdVacancy { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOut { get; set; }

        public int? IdAbsence { get; set; }

        public virtual Absence Absence { get; set; }

        public virtual Person Person { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentation> Documentations { get; set; }

        public virtual Vacancy Vacancy { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timeshift> Timeshifts { get; set; }
    }
}