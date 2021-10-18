using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("Review")]
    public partial class Review
    {
        [Key]
        public int Id { get; set; }
        [Column("InterviewerID")]
        public int InterviewerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [StringLength(100)]
        public string Pros { get; set; }
        [StringLength(100)]
        public string Cons { get; set; }
        [Column("CandidateStatusID")]
        public int CandidateStatusId { get; set; }
        [Required]
        [StringLength(100)]
        public string InterviewerComments { get; set; }

        [ForeignKey(nameof(CandidateStatusId))]
        [InverseProperty("Reviews")]
        public virtual CandidateStatus CandidateStatus { get; set; }
        [ForeignKey(nameof(InterviewerId))]
        [InverseProperty("Reviews")]
        public virtual Interviewer Interviewer { get; set; }
    }
}
