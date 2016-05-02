using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.Goods")]
    public class Good
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            Books = new HashSet<Book>();
            GoodsMoves = new HashSet<GoodsMove>();
        }

        [Key]
        public int IdGoods { get; set; }

        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public string GoodName { get; set; }

        public int Term { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsMove> GoodsMoves { get; set; }
    }
}