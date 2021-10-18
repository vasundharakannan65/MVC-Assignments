using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("Status")]
    public partial class Status
    {
        public Status()
        {
            CandidateStatuses = new HashSet<CandidateStatus>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty(nameof(CandidateStatus.Status))]
        public virtual ICollection<CandidateStatus> CandidateStatuses { get; set; }
    }
}
