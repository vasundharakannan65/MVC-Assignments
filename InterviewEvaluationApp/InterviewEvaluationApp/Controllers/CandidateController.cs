using InterviewEvaluationApp.Interfaces;
using InterviewEvaluationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewEvaluationApp.Controllers
{
    //[Authorize(Roles="HR")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateController(ICandidateRepository candidateRepository)
        {
            this._candidateRepository = candidateRepository;
        }

        //GetAllCandidates
        [HttpGet]
        public async Task<IEnumerable<Candidate>> GetAllCandidates()
        {
            return await _candidateRepository.GetAllCandidates();
        }

        //GetCandidateByID 
        [HttpGet("{id}")]
        public async Task<Candidate> GetCandidate(int id)
        {
            return await _candidateRepository.GetCandidateById(id);
        }

        //Create
        [HttpPost]
        public void CreateCandidate([FromBody] Candidate candidate)
        {
            _candidateRepository.AddCandidate(candidate);
        }

        ////Update
        //[HttpPut("{id}")]
        //public void UpdateCandidate(int id,[FromBody]Candidate candidate)
        //{
        //    candidate.Id = id;
        //    _candidateRepository.UpdateCandidate(candidate);
        //} 

        ////Delete
        //[HttpDelete("{id}")]
        //public void DeleteCandidate(int id)
        //{
        //    _candidateRepository.DeleteCandidate(id);
        //}


    }
}
