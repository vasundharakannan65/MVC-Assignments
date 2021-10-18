using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InterviewEvaluationApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace InterviewEvaluationApp.Data
{
    public partial class CandidateInterviewEvaluationDBContext : IdentityDbContext<ApplicationUser>
    {
        public CandidateInterviewEvaluationDBContext()
        {
        }

        public CandidateInterviewEvaluationDBContext(DbContextOptions<CandidateInterviewEvaluationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateStatus> CandidateStatuses { get; set; }
        public virtual DbSet<Interviewer> Interviewers { get; set; }
        public virtual DbSet<InterviewerRating> InterviewerRatings { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillRating> SkillRatings { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        
    }
}
