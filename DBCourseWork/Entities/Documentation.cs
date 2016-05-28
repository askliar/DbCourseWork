using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.Documentation")]
    public class Documentation
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Documentation()
        {
            GoodsMoves = new HashSet<GoodsMove>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime DocDate { get; set; }

        public int IdDoctype { get; set; }

        public int? IdContr { get; set; }

        public int? IdStuff { get; set; }

        public virtual Stuff Stuff { get; set; }

        public virtual Contractor Contractor { get; set; }

        public virtual DocType DocType { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsMove> GoodsMoves { get; set; }
    }
}