import { AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit, Component, DoCheck, OnChanges, OnInit } from "@angular/core";

@Component({
    selector : 'app-child',
    templateUrl : './child.component.html'
})

export class ChildComponent implements OnInit,OnChanges,DoCheck,AfterContentInit,AfterContentChecked,
AfterViewInit,AfterViewChecked {
  constructor() {
    console.log("constructor of child is called");
  } 

  ngOnInit()
  {
    console.log("ngOnInit of child is called");
  }

  ngOnChanges()
  {
    console.log("ngOnChanges of child is called");
  }

  ngDoCheck()
  {
    console.log("ngDoCheck of child is called");
  } 

  ngAfterContentInit()
  {
    console.log("ngAfterContentInit of child is called");
  } 

  ngAfterContentChecked()
  {
    console.log("ngAfterContentChecked of child is called");
  }

  ngAfterViewInit()
  {
    console.log("ngAfterViewInit of child is called");
  }

  ngAfterViewChecked()
  {
    console.log("ngAfterViewChecked of child is called");
  }
    
}