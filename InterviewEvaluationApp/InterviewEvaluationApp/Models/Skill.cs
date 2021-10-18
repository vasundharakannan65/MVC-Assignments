using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("Skill")]
    public partial class Skill
    {
        public Skill()
        {
            SkillRatings = new HashSet<SkillRating>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [InverseProperty(nameof(SkillRating.Skill))]
        public virtual ICollection<SkillRating> SkillRatings { get; set; }
    }
}
