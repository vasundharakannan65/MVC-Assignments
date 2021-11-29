import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CandidateService } from 'src/app/services/candidate.service';
import { ViewdetailsMCComponent } from '../viewdetails-mc/viewdetails-mc.component';

@Component({
  selector: 'app-manage-candidates',
  templateUrl: './manage-candidates.component.html',
  styleUrls: ['./manage-candidates.component.css']
})
export class ManageCandidatesComponent implements OnInit {

  constructor(public modalService: NgbModal,
    private candidateService : CandidateService) { }

  candidates : any = [];

openModal() {
  const modalRef = this.modalService.open(ViewdetailsMCComponent,
    {
      scrollable: true,
      windowClass: 'myCustomModalClass',
    });

  modalRef.result.then((result:any) => {
    console.log(result);
  }, (reason:any) => {
  });
} 


ngOnInit() 
{
  this.getAllCandidate();
}

// Getting list of Candidates
getAllCandidate(): void {
  this.candidateService.list().subscribe((candidates: any) => {this.candidates = candidates;},
  (error: any) => {console.log(error);});
}

}
