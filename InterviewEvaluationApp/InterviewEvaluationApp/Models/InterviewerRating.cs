using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("InterviewerRating")]
    public partial class InterviewerRating
    {
        [Key]
        public int Id { get; set; }
        public int InterviewerId { get; set; }
        [Column("CandidateID")]
        public int CandidateId { get; set; }
        [Column("RoundID")]
        public int RoundId { get; set; }
        [Column("SKillRatingID")]
        public int SkillRatingId { get; set; }
        [Column("RatingID")]
        public int RatingId { get; set; }

        [ForeignKey(nameof(CandidateId))]
        [InverseProperty("InterviewerRatings")]
        public virtual Candidate Candidate { get; set; }
        [ForeignKey(nameof(InterviewerId))]
        [InverseProperty("InterviewerRatings")]
        public virtual Interviewer Interviewer { get; set; }
        [ForeignKey(nameof(RatingId))]
        [InverseProperty("InterviewerRatings")]
        public virtual Rating Rating { get; set; }
        [ForeignKey(nameof(RoundId))]
        [InverseProperty("InterviewerRatings")]
        public virtual Round Round { get; set; }
        [ForeignKey(nameof(SkillRatingId))]
        [InverseProperty("InterviewerRatings")]
        public virtual SkillRating SkillRating { get; set; }
    }
}
