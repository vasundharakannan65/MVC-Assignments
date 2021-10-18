using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("SkillRating")]
    public partial class SkillRating
    {
        public SkillRating()
        {
            InterviewerRatings = new HashSet<InterviewerRating>();
        }

        [Key]
        public int Id { get; set; }
        [Column("SkillID")]
        public int SkillId { get; set; }
        [Required]
        [StringLength(30)]
        public string SubSkillName { get; set; }

        [ForeignKey(nameof(SkillId))]
        [InverseProperty("SkillRatings")]
        public virtual Skill Skill { get; set; }
        [InverseProperty(nameof(InterviewerRating.SkillRating))]
        public virtual ICollection<InterviewerRating> InterviewerRatings { get; set; }
    }
}
