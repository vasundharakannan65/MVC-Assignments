import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HRDashboardComponent } from './dashboard/hrdashboard/hrdashboard.component';
import { AddCandidatesComponent } from './dashboard/hrdashboard/add-candidates/add-candidates.component';
import { ScheduleInterviewsComponent } from './dashboard/hrdashboard/schedule-interviews/schedule-interviews.component';
import { ManageCandidatesComponent } from './dashboard/hrdashboard/manage-candidates/manage-candidates.component';
import { InterviewerDashboardComponent } from './dashboard/interviewer-dashboard/interviewer-dashboard.component';
import { LoginComponent } from './Authorization/login/login.component';
import { RegisterComponent } from './Authorization/register/register.component';
import { ProfileScreeningComponent } from './dashboard/hrdashboard/profile-screening/profile-screening.component';
import { TelephonicInterviewComponent } from './dashboard/hrdashboard/telephonic-interview/telephonic-interview.component';
import { TechnicalTelephonicInterviewComponent } from './dashboard/hrdashboard/technical-telephonic-interview/technical-telephonic-interview.component';
import { TechnicalSystemTestComponent } from './dashboard/hrdashboard/technical-system-test/technical-system-test.component';
import { TechinalF2fInterviewComponent } from './dashboard/hrdashboard/techinal-f2f-interview/techinal-f2f-interview.component';
import { FinalF2fComponent } from './dashboard/hrdashboard/final-f2f/final-f2f.component';
import { AddRatingComponent } from './dashboard/interviewer-dashboard/add-rating/add-rating.component';
import { AssignInterviewsComponent } from './dashboard/hrdashboard/assign-interviews/assign-interviews.component';
import { NgbActiveModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ViewdetailsdComponent } from './dashboard/hrdashboard/viewdetailsd/viewdetailsd.component';
import { ViewdetailsMCComponent } from './dashboard/hrdashboard/viewdetails-mc/viewdetails-mc.component';
import { AddStatusComponent } from './dashboard/hrdashboard/add-status/add-status.component';


const appRouting : Routes = [
  { path: '',component: LoginComponent },
  { path: 'register',component:RegisterComponent },
  { path: 'main',component:DashboardComponent,
  children : [
      { path: 'HRDashboard',component:HRDashboardComponent },
      { path: 'addCandidate',component:AddCandidatesComponent },
      { path: 'scheduledInterviews',component: ScheduleInterviewsComponent },
      { path: 'assignInterviews',component: AssignInterviewsComponent },
      { path: 'manageCandidates',component:ManageCandidatesComponent },
      { path: 'manageCandidates/:id',component:ManageCandidatesComponent },
      { path: 'profileScreening',component:ProfileScreeningComponent },
      { path: 'telephonicInterview',component:TelephonicInterviewComponent },
      { path: 'technicalTelephonicInterview',component:TechnicalTelephonicInterviewComponent },
      { path: 'technicalSystemTest',component:TechnicalSystemTestComponent },
      { path: 'technicalF2FInterview',component:TechinalF2fInterviewComponent },
      { path: 'finalF2F',component:FinalF2fComponent },
      { path: 'InterviewerDashboard',component:InterviewerDashboardComponent },
      { path: 'AddRating',component:AddRatingComponent }
    ] }
]

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    HRDashboardComponent,
    AddCandidatesComponent,
    ScheduleInterviewsComponent,
    ManageCandidatesComponent,
    InterviewerDashboardComponent,
    LoginComponent,
    RegisterComponent,
    ProfileScreeningComponent,
    TelephonicInterviewComponent,
    TechnicalTelephonicInterviewComponent,
    TechnicalSystemTestComponent,
    TechinalF2fInterviewComponent,
    FinalF2fComponent,
    AddRatingComponent,
    AssignInterviewsComponent,
    ViewdetailsdComponent,
    ViewdetailsMCComponent,
    AddStatusComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forRoot(appRouting)
  ],
  providers: [NgbActiveModal],
  bootstrap: [AppComponent]
})
export class AppModule { }
