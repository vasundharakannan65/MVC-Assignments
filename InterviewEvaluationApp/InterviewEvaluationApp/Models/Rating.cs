using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Models
{
    [Table("Rating")]
    public partial class Rating
    {
        public Rating()
        {
            InterviewerRatings = new HashSet<InterviewerRating>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Factors { get; set; }

        [InverseProperty(nameof(InterviewerRating.Rating))]
        public virtual ICollection<InterviewerRating> InterviewerRatings { get; set; }
    }
}
