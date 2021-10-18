using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InterviewEvaluationApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


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

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public  DbSet<Candidate> Candidates { get; set; }
        public  DbSet<CandidateStatus> CandidateStatuses { get; set; }
        public  DbSet<Interviewer> Interviewers { get; set; }
        public  DbSet<InterviewerRating> InterviewerRatings { get; set; }
        public  DbSet<Rating> Ratings { get; set; }
        public  DbSet<Review> Reviews { get; set; }
        public  DbSet<Round> Rounds { get; set; }
        public  DbSet<Skill> Skills { get; set; }
        public  DbSet<SkillRating> SkillRatings { get; set; }
        public  DbSet<Status> Statuses { get; set; }


    
    }
}
