import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CandidateService } from 'src/app/services/candidate.service';

@Component({
  selector: 'app-viewdetails-mc',
  templateUrl: './viewdetails-mc.component.html',
  styleUrls: ['./viewdetails-mc.component.css']
})
export class ViewdetailsMCComponent implements OnInit {

  currentCandidate : any;

  id !: number;

  constructor(public activeModal: NgbActiveModal,
    private candidateService : CandidateService,
    private route : ActivatedRoute,
    private router : Router) {
      this.currentCandidate = []
     }

  ngOnInit(): void {
    this.candidateService.getItem(this.route.snapshot.params['id']).subscribe((data: any) => {
      this.currentCandidate = data;
    });
  }

  closeModal(message: string) {
    this.activeModal.close();
  }

}
