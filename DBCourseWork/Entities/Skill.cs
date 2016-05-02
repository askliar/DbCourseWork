using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.Skills")]
    public class Skill
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skill()
        {
            NecessarySkills = new HashSet<NecessarySkill>();
            PersonalSkills = new HashSet<PersonalSkill>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdSkill { get; set; }

        [Required]
        [StringLength(25)]
        public string SkillName { get; set; }

        [Required]
        [StringLength(256)]
        public string SkillDescription { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NecessarySkill> NecessarySkills { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalSkill> PersonalSkills { get; set; }
    }
}