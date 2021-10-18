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


        //CREATE CANDIDATE
        public void AddCandidate(Candidate candidate)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[SP_AddCandidate]";

            DynamicParameters parameters = new();

            parameters.Add("Name", candidate.Name);
            parameters.Add("ReferralName",candidate.ReferralName);
            parameters.Add("CurrentLastEmployer",candidate.CurrentLastEmployer);
            parameters.Add("CurrentLastDesignation",candidate.CurrentLastDesignation);
            parameters.Add("TotalExperience",candidate.TotalExperience);
            parameters.Add("NoticePeriod",candidate.NoticePeriod);
            parameters.Add("Sources",candidate.Sources);
            parameters.Add("Others",candidate.Others);
            parameters.Add("HealthCondition",candidate.HealthCondition);
            parameters.Add("Designation",candidate.Designation);
            parameters.Add("Resume",candidate.Resume);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameters);

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


        //UPDATE
        public void UpdateCandidate(int id,Candidate candidate)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[SP_UpdateCandidate]";

            DynamicParameters parameters = new();

            parameters.Add("Id", id);
            parameters.Add("Name", candidate.Name);
            parameters.Add("ReferralName", candidate.ReferralName);
            parameters.Add("CurrentLastEmployer", candidate.CurrentLastEmployer);
            parameters.Add("CurrentLastDesignation", candidate.CurrentLastDesignation);
            parameters.Add("TotalExperience", candidate.TotalExperience);
            parameters.Add("NoticePeriod", candidate.NoticePeriod);
            parameters.Add("Sources", candidate.Sources);
            parameters.Add("Others", candidate.Others);
            parameters.Add("HealthCondition", candidate.HealthCondition);
            parameters.Add("Designation", candidate.Designation);
            parameters.Add("Resume", candidate.Resume);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameters);

        }

        //DELETE
        public void DeleteCandidate(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[SP_DeleteCandidate]";

            DynamicParameters parameters = new();

            parameters.Add("@Id", id);

            SqlMapper.Execute(dbConnection, sp, commandType: CommandType.StoredProcedure, param: parameters);

        }

    }
    
}
