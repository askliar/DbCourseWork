using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.Contractors")]
    public class Contractor
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contractor()
        {
            Documentations = new HashSet<Documentation>();
            EntityContrs = new HashSet<EntityContr>();
            IndividContrs = new HashSet<IndividContr>();
        }

        [Key]
        public int IdContr { get; set; }

        [Required]
        [StringLength(50)]
        public string ContrName { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int? IdCard { get; set; }

        public virtual Card Card { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentation> Documentations { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EntityContr> EntityContrs { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IndividContr> IndividContrs { get; set; }
    }
}