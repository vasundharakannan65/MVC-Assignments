import { Component, OnInit } from '@angular/core';
import { CandidateService } from 'src/app/services/candidate.service';

@Component({
  selector: 'app-add-candidates',
  templateUrl: './add-candidates.component.html',
  styleUrls: ['./add-candidates.component.css']
})
export class AddCandidatesComponent implements OnInit {

  constructor(private candidateService : CandidateService) { }

  data = {
    name : ' ',
    referralName : ' ',
    currentLastEmployer : ' ',
    currentLastDesignation : ' ',
    totalExpierence : 0,
    noticePeriod : 0,
    sources : ' ',
    others : ' ',
    designation : ' ',
    resume : ' ',
    healthCondition : false
  }

  ngOnInit(): void {
  }

  addNewCandidate() : void
  {   
    const datas = {
      Name : this.data.name,
      ReferralName : this.data.referralName,
      CurrentLastEmployer : this.data.currentLastEmployer,
      CurrentLastDesignation : this.data.currentLastDesignation,
      HealthCondition : this.data.healthCondition,
      TotalExpierence : this.data.totalExpierence,
      NoticePeriod : this.data.noticePeriod,
      Sources : this.data.sources,
      Others : this.data.others,
      Designation : this.data.designation,
      Resume : this.data.resume
    };
 
    this.candidateService.create(datas)
      .subscribe((data) => {console.warn("New Candidate has been added successfully!"),datas})
  }

}
