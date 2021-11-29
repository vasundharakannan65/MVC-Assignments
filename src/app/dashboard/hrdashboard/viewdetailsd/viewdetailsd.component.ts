import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-viewdetailsd',
  templateUrl: './viewdetailsd.component.html',
  styleUrls: ['./viewdetailsd.component.css']
})
export class ViewdetailsdComponent implements OnInit {

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit(): void {
  }

  closeModal(message: string) {
    this.activeModal.close();
  }
}
