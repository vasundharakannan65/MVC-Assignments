using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("Round")]
    public partial class Round
    {
        public Round()
        {
            CandidateStatuses = new HashSet<CandidateStatus>();
            InterviewerRatings = new HashSet<InterviewerRating>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(CandidateStatus.Round))]
        public virtual ICollection<CandidateStatus> CandidateStatuses { get; set; }
        [InverseProperty(nameof(InterviewerRating.Round))]
        public virtual ICollection<InterviewerRating> InterviewerRatings { get; set; }
    }
}
