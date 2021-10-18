using Dapper;
using InterviewEvaluationApp.Interfaces;
using InterviewEvaluationApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewEvaluationApp.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IConfiguration _configuration;
        public CandidateRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }


        //CREATE
        public void AddCandidate(Candidate candidate)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[SP_AddCandidate]";

            DynamicParameters parameters = new();

            parameters.AddDynamicParams(new
            {
                @Name = candidate.Name,
                @ReferralName = candidate.ReferralName,                                              
                @CurrentLastEmployer = candidate.CurrentLastEmployer,                                              
                @CurrentLastDesignation = candidate.CurrentLastDesignation,                                              
                @TotalExperience = candidate.TotalExperience,                                             
                @NoticePeriod = candidate.NoticePeriod,                                              
                @Sources = candidate.Sources,
                @Others = candidate.Others,                                              
                @HealthCondition = candidate.HealthCondition
            });

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure,param: parameters);
           
        }

        //GET ALL CANDIDATES
        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[SP_DisplayAllCandidates]";

            var listOfCandidates = await Task.FromResult(dbConnection.Query<Candidate>(sp, commandType: CommandType.StoredProcedure).ToList());

            return listOfCandidates;
        }

        //GET CANDIDATE BY ID
        public async Task<Candidate> GetCandidateById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[SP_DisplayCandidateUsingID]";

            DynamicParameters parameters = new();

            parameters.Add("@Id", id);

            return await Task.FromResult(dbConnection.Query<Candidate>(sp, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault());

            }
        }

        ////UPDATE
        //public void UpdateCandidate(Candidate candidate)
        //{
        //    using (IDbConnection dbConnection = Connection)
        //    {
        //        string sql = @"UPDATE CANDIDATE 
        //                            SET 
        //                            Name = @Name
        //                            ,ReferralName = @ReferralName
        //                            ,CurrentLastEmployer = @CurrentLastEmployer
        //                            ,CurrentLastDesignation = @CurrentLastDesignation
        //                            ,TotalExperience = @TotalExperience
        //                            ,NoticePeriod = @NoticePeriod
        //                            ,Sources = @Sources
        //                            ,Others = @Others
        //                            ,HealthCondition = @HealthCondition
        //                            WHERE Id = @id";

        //        dbConnection.Open();
        //        dbConnection.Query<Candidate>(sql, candidate);
        //    }
        //}

        ////DELETE
        //public void DeleteCandidate(int id)
        //{
        //    using (IDbConnection dbConnection = Connection)
        //    {
        //        string sql = @"DELETE FROM CANDIDATE 
        //                              WHERE Id = @id";

        //        dbConnection.Open();
        //        dbConnection.Query<Candidate>(sql, new { Id = id });
        //    }
        //}
    
}
