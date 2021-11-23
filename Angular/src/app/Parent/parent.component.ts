import { AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit,
  Component, DoCheck, OnChanges, OnInit } from '@angular/core';


@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html'
})

export class ParentComponent implements OnInit,OnChanges,DoCheck,AfterContentInit,AfterContentChecked,
AfterViewInit,AfterViewChecked {

  title : string = 'Trying Angular Lifecycle hooks!'

  constructor() {
    console.log("constructor of parent is called");
  } 

  ngOnInit()
  {
    console.log("ngOnInit of parent is called");
  }

  ngOnChanges()
  {
    console.log("ngOnChanges of parent is called");
  }

  ngDoCheck()
  {
    console.log("ngDoCheck of parent is called");
  } 

  ngAfterContentInit()
  {
    console.log("ngAfterContentInit of parent is called");
  } 

  ngAfterContentChecked()
  {
    console.log("ngAfterContentChecked of parent is called");
  }

  ngAfterViewInit()
  {
    console.log("ngAfterViewInit of parent is called");
  }

  ngAfterViewChecked()
  {
    console.log("ngAfterViewChecked of parent is called");
  }
}