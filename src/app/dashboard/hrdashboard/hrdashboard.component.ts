import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ViewdetailsdComponent } from './viewdetailsd/viewdetailsd.component';

@Component({
  selector: 'app-hrdashboard',
  templateUrl: './hrdashboard.component.html',
  styleUrls: ['./hrdashboard.component.css']
})
export class HRDashboardComponent implements OnInit {

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

}
