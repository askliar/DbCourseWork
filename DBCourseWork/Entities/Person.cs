using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.Person")]
    public class Person
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            PersonalSkills = new HashSet<PersonalSkill>();
            Stuffs = new HashSet<Stuff>();
            UserRoles = new HashSet<UserRole>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPerson { get; set; }

        [Required]
        [StringLength(15)]
        public string PerName { get; set; }

        [Required]
        [StringLength(15)]
        public string PerSurname { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(50)]
        public string Education { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalSkill> PersonalSkills { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stuff> Stuffs { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}