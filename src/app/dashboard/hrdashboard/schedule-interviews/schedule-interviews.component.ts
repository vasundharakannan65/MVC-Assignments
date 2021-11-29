import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ViewdetailsMCComponent } from '../viewdetails-mc/viewdetails-mc.component';
import { ViewdetailsdComponent } from '../viewdetailsd/viewdetailsd.component';

@Component({
  selector: 'app-schedule-interviews',
  templateUrl: './schedule-interviews.component.html',
  styleUrls: ['./schedule-interviews.component.css']
})
export class ScheduleInterviewsComponent implements OnInit {

  constructor(public modalService: NgbModal) { }

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


ngOnInit() : void
{

}



}
