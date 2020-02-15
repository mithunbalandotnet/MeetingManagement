import { Component, OnInit } from '@angular/core';
import { Meeting } from 'src/app/models/meeting';
import { Attendee } from 'src/app/models/attendee';
import { MeetingService } from 'src/app/services/meeting.service';

@Component({
  selector: 'app-meeting-add',
  templateUrl: './meeting-add.component.html',
  styleUrls: ['./meeting-add.component.scss']
})
export class MeetingAddComponent implements OnInit {
  meeting:Meeting;
  attendeesGlobal:Array<Attendee>;
  
  constructor(private meetingService: MeetingService) { }

  ngOnInit() {
    this.getAttendees();
  }

  getAttendees(){
    this.meetingService.getAttendees().subscribe(data => {
      this.attendeesGlobal = data;  
    });
  }
}
