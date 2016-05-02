using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.Vacancies")]
    public class Vacancy
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vacancy()
        {
            Stuffs = new HashSet<Stuff>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdVacancy { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOut { get; set; }

        public int IdPosition { get; set; }

        public virtual Position Position { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stuff> Stuffs { get; set; }
    }
}