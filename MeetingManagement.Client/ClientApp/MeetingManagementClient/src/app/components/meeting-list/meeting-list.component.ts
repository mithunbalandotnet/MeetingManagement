import { Component, OnInit, OnDestroy } from '@angular/core';
import { MeetingService } from 'src/app/services/meeting.service';
import { Meeting } from 'src/app/models/meeting';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-meeting-list',
  templateUrl: './meeting-list.component.html',
  styleUrls: ['./meeting-list.component.scss']
})
export class MeetingListComponent implements OnInit, OnDestroy {
  
  meetings: Array<Meeting>;
  constructor(private meetingService: MeetingService,
    private toastr: ToastrService) {
    this.meetings = [];
      this.getMeetings();
   }

  ngOnInit() {
  }

  getMeetings(){
    this.meetingService.getMeetings().subscribe(data => {
      this.meetings = data.map(function(d) { return { id: d.id, subject: d.subject, meetingAgenda : d.meetingAgenda, 
        meetingDateTime: new Date(d.meetingDateTime + 'Z'), attendees : d.attendees }; });
      this.meetings.forEach(function(m){
        m.attendeesList = m.attendees.map(function(a) { return a.name; }).join(';');
      });
    },
    error => {
      this.toastr.error("error in fetching");
    });
  }

  Delete(e, id){
    this.meetingService.deleteMeeting(id).subscribe(data => {
      this.toastr.success("Meeting deleted");
      this.getMeetings();
    }, error => {
      this.toastr.error("error in deleting");
    });
  }
  ngOnDestroy(): void {
  }
}
