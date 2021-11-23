import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppComponent } from "./app.component";
import { ChildComponent } from "./Parent/Child/child.component";
import { ParentComponent } from "./Parent/parent.component";


@NgModule({
    declarations: [
      AppComponent,
      ParentComponent,
      ChildComponent
    ],
    imports: [
      BrowserModule
    ],
    providers: [],
    bootstrap: [AppComponent]
  })
  
export class AppModule { }