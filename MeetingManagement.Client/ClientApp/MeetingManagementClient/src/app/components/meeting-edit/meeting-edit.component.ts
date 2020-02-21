import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Meeting } from 'src/app/models/meeting';
import { ApiService } from 'src/app/services/api.service';
import { ToastrService } from 'ngx-toastr';
import { NgbDateStruct, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { MeetingService } from 'src/app/services/meeting.service';

@Component({
  selector: 'app-meeting-edit',
  templateUrl: './meeting-edit.component.html',
  styleUrls: ['./meeting-edit.component.scss']
})
export class MeetingEditComponent implements OnInit, OnDestroy {  
  id:number;
  meeting:Meeting;
  attendeesGlobal:Array<any>;
  meetingDate:NgbDateStruct;
  dropdownSettings:IDropdownSettings;
  
  constructor(private route: ActivatedRoute,
    private apiService: ApiService,
    private toastr: ToastrService,
    private calendar: NgbCalendar,
    private meetingService: MeetingService,
    private router: Router) { 
    this.route.params.subscribe(params => {
      this.id = params['id'];
      this.getMeeting();
    });
  }

  ngOnInit() {
    this.getAttendees();
    this.meeting = {id : 0, subject : "", meetingDateTime : new Date(), meetingAgenda : "", attendees: [], attendeesList:""};
    this.meetingDate = this.calendar.getToday();
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

  getMeeting() {
    this.apiService.get("meeting/getmeeting",{ id : this.id }).subscribe(data => {
      this.meeting = data;
      this.meeting.meetingDateTime = new Date(data.meetingDateTime + 'Z');
    }, 
      error => {
        this.toastr.error("Error occured");
      })
  }
  SaveClick(e){
    if(this.validate()){
      this.apiService.post("meeting/update", this.meeting).subscribe(data => {
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
    
    return true;
  }

  ngOnDestroy(): void {
    
  }
}
