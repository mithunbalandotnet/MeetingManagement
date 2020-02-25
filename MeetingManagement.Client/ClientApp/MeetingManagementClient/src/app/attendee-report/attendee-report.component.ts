import { Component, OnInit } from '@angular/core';
import { MeetingService } from '../services/meeting.service';

@Component({
  selector: 'app-attendee-report',
  templateUrl: './attendee-report.component.html',
  styleUrls: ['./attendee-report.component.scss']
})
export class AttendeeReportComponent implements OnInit {
  attendeeReport:Array<any>;
  constructor(private meetingService: MeetingService) { 
      this.getAttendeeReport();

  }

  getAttendeeReport() {
    this.meetingService.getAttendeeReport().subscribe(data => {
      this.attendeeReport = data;
    }, error => {});
  }
  ngOnInit() {
  }

}
