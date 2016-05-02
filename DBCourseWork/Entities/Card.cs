using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.Cards")]
    public class Card
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Card()
        {
            Contractors = new HashSet<Contractor>();
        }

        [Key]
        public int IdCard { get; set; }

        public int? IdAction { get; set; }

        public virtual Action Action { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contractor> Contractors { get; set; }
    }
}