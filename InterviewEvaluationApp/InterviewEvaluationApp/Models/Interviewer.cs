using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("Interviewer")]
    public partial class Interviewer
    {
        public Interviewer()
        {
            InterviewerRatings = new HashSet<InterviewerRating>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Sign { get; set; }

        [InverseProperty(nameof(InterviewerRating.Interviewer))]
        public virtual ICollection<InterviewerRating> InterviewerRatings { get; set; }
        [InverseProperty(nameof(Review.Interviewer))]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
