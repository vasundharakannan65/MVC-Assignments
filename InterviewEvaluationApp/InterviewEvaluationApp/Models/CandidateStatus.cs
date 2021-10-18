using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("CandidateStatus")]
    public partial class CandidateStatus
    {
        public CandidateStatus()
        {
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }
        [Column("CandidateID")]
        public int CandidateId { get; set; }
        [Column("RoundID")]
        public int RoundId { get; set; }
        [Column("StatusID")]
        public int StatusId { get; set; }

        [ForeignKey(nameof(CandidateId))]
        [InverseProperty("CandidateStatuses")]
        public virtual Candidate Candidate { get; set; }
        [ForeignKey(nameof(RoundId))]
        [InverseProperty("CandidateStatuses")]
        public virtual Round Round { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty("CandidateStatuses")]
        public virtual Status Status { get; set; }
        [InverseProperty(nameof(Review.CandidateStatus))]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
