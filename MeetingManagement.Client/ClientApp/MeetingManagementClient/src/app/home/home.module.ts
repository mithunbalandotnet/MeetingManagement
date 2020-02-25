import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../components/home/home.component';
import { MeetingListComponent } from '../components/meeting-list/meeting-list.component';
import { MeetingAddComponent } from '../components/meeting-add/meeting-add.component';
import { homeRoutingModule } from './homeRouting';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MeetingEditComponent } from '../components/meeting-edit/meeting-edit.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';
import { AttendeeReportComponent } from '../attendee-report/attendee-report.component';

@NgModule({
  declarations: [
    HomeComponent,
    MeetingListComponent,
    MeetingAddComponent,
    MeetingEditComponent,
    AttendeeReportComponent
  ],
  imports: [
    CommonModule,
    homeRoutingModule,
    FormsModule,
    NgbModule,
    NgMultiSelectDropDownModule.forRoot(),
    ToastrModule.forRoot(),
    OwlDateTimeModule, 
    OwlNativeDateTimeModule
  ]
})
export class HomeModule { }
