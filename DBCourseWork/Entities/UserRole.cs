using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Sklyar_A.UserRoles")]
    public class UserRole
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(20)]
        public string Login { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        public virtual Person Person { get; set; }
    }
}