using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("Candidate")]
    public partial class Candidate
    {
        public Candidate()
        {
            CandidateStatuses = new HashSet<CandidateStatus>();
            InterviewerRatings = new HashSet<InterviewerRating>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string ReferralName { get; set; }
        [Required]
        [StringLength(50)]
        public string CurrentLastEmployer { get; set; }
        [Required]
        [StringLength(50)]
        public string CurrentLastDesignation { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal TotalExperience { get; set; }
        public int? NoticePeriod { get; set; }
        [StringLength(50)]
        public string Sources { get; set; }
        [StringLength(50)]
        public string Others { get; set; }
        public bool? HealthCondition { get; set; }

        [InverseProperty(nameof(CandidateStatus.Candidate))]
        public virtual ICollection<CandidateStatus> CandidateStatuses { get; set; }
        [InverseProperty(nameof(InterviewerRating.Candidate))]
        public virtual ICollection<InterviewerRating> InterviewerRatings { get; set; }
    }
}
