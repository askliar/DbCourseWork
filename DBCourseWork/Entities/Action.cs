using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.Actions")]
    public class Action
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Action()
        {
            Cards = new HashSet<Card>();
        }

        [Key]
        public int IdAction { get; set; }

        [Column(TypeName = "date")]
        public DateTime DayStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime DayStop { get; set; }

        public double? Percents { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Card> Cards { get; set; }
    }
}