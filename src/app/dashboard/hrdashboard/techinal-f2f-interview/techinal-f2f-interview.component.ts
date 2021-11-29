import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddStatusComponent } from '../add-status/add-status.component';
import { ViewdetailsdComponent } from '../viewdetailsd/viewdetailsd.component';

@Component({
  selector: 'app-techinal-f2f-interview',
  templateUrl: './techinal-f2f-interview.component.html',
  styleUrls: ['./techinal-f2f-interview.component.css']
})
export class TechinalF2fInterviewComponent implements OnInit {

  constructor(public modalService: NgbModal) { }

openModal() {
  const modalRef = this.modalService.open(ViewdetailsdComponent,
    {
      scrollable: true,
      windowClass: 'myCustomModalClass',
    });

  modalRef.result.then((result:any) => {
    console.log(result);
  }, (reason:any) => {
  });
} 


ngOnInit() : void
{

}

openModalStatus() {
  const modalRef = this.modalService.open(AddStatusComponent,
    {
      scrollable: true,
      windowClass: 'myCustomModalClass',
    });

  modalRef.result.then((result:any) => {
    console.log(result);
  }, (reason:any) => {
  }); 
}

}
