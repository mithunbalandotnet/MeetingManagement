import { Component, OnInit, OnDestroy } from '@angular/core';
import { Meeting } from 'src/app/models/meeting';
import { MeetingService } from 'src/app/services/meeting.service';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import {NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-meeting-add',
  templateUrl: './meeting-add.component.html',
  styleUrls: ['./meeting-add.component.scss']
})
export class MeetingAddComponent implements OnInit, OnDestroy {
  meeting:Meeting;
  attendeesGlobal:Array<any>;
  selectedAttendees: Array<any>;
  meetingDate:Date;
  dropdownSettings:IDropdownSettings;

  constructor(private meetingService: MeetingService,
    private apiService: ApiService,
    private router: Router,
    private calendar: NgbCalendar,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.getAttendees();
    this.meeting = {id : 0, subject : "", meetingDateTime : new Date(), meetingAgenda : "", attendees: [], attendeesList:""};
    this.meetingDate = new Date();
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 10,
      allowSearchFilter: true
    };
  }

  getAttendees(){
    this.meetingService.getAttendees().subscribe(data => {
      this.attendeesGlobal = data;  
    });
  }

  SaveClick(e){
    if(this.validate()){
      this.apiService.post("meeting/add", this.meeting).subscribe(data => {
        this.toastr.success("Meeting added");
        this.router.navigate(['/meetings'])
      },
      error => {
        this.toastr.error("Error occured while adding");
      });
    }
  }
  validate():boolean{
    if(this.meeting.subject.length == 0){
      this.toastr.error("Please enter subject");
      return false;
    }
    if(this.meeting.meetingAgenda.length == 0){
      this.toastr.error("Please enter Agenda");
      return false;
    }
    if(this.meeting.attendees.length ==0){
      this.toastr.error("Please select at least one attendee");
      return false;
    }
    //this.meeting.meetingDateTime = new Date(this.meetingDate.getFullYear(), this.meetingDate.getMonth(), this.meetingDate.getDate(), this.meetingDate.getHours(), this.meetingDate.getMinutes());
    return true;
  }
  ngOnDestroy(): void {
    
  }
}
