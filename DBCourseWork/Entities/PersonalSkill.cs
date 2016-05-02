using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.PersonalSkills")]
    public class PersonalSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPerSkils { get; set; }

        public int IdPerson { get; set; }

        public int IdSkill { get; set; }

        public virtual Person Person { get; set; }

        public virtual Skill Skill { get; set; }
    }
}