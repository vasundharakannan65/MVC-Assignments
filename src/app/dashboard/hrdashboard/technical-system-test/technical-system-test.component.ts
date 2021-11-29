import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddStatusComponent } from '../add-status/add-status.component';
import { ViewdetailsdComponent } from '../viewdetailsd/viewdetailsd.component';

@Component({
  selector: 'app-technical-system-test',
  templateUrl: './technical-system-test.component.html',
  styleUrls: ['./technical-system-test.component.css']
})
export class TechnicalSystemTestComponent implements OnInit {

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
