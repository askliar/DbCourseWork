using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCourseWork.Entities
{
    [Table("Remizov_O.NecessarySkills")]
    public class NecessarySkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdNecSkill { get; set; }

        public int IdSkill { get; set; }

        public int IdPosition { get; set; }

        public virtual Position Position { get; set; }

        public virtual Skill Skill { get; set; }
    }
}