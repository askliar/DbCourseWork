using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.Positions")]
    public class Position
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Position()
        {
            NecessarySkills = new HashSet<NecessarySkill>();
            Vacancies = new HashSet<Vacancy>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPosition { get; set; }

        [Required]
        [StringLength(30)]
        public string VacName { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NecessarySkill> NecessarySkills { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}