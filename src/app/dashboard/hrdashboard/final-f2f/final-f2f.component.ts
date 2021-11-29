import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddStatusComponent } from '../add-status/add-status.component';
import { ViewdetailsdComponent } from '../viewdetailsd/viewdetailsd.component';

@Component({
  selector: 'app-final-f2f',
  templateUrl: './final-f2f.component.html',
  styleUrls: ['./final-f2f.component.css']
})
export class FinalF2fComponent implements OnInit {

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
  
  ngOnInit() : void
  {
  
  }
}
