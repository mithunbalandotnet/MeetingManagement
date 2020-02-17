import { Component, OnInit, OnDestroy } from '@angular/core';
import { MeetingService } from 'src/app/services/meeting.service';
import { Meeting } from 'src/app/models/meeting';

@Component({
  selector: 'app-meeting-list',
  templateUrl: './meeting-list.component.html',
  styleUrls: ['./meeting-list.component.scss']
})
export class MeetingListComponent implements OnInit, OnDestroy {
  
  meetings: Array<Meeting>;
  constructor(private meetingService: MeetingService) {
    this.meetings = [];
      this.getMeetings();
   }

  ngOnInit() {
  }

  getMeetings(){
    this.meetingService.getMeetings().subscribe(data => {
      
    });
  }

  ngOnDestroy(): void {
  }
}
