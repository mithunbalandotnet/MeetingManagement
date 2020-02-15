import { Component, OnInit } from '@angular/core';
import { MeetingService } from 'src/app/services/meeting.service';
import { Meeting } from 'src/app/models/meeting';

@Component({
  selector: 'app-meeting-list',
  templateUrl: './meeting-list.component.html',
  styleUrls: ['./meeting-list.component.scss']
})
export class MeetingListComponent implements OnInit {
  meetings: Array<Meeting>;
  constructor(private meetingService: MeetingService) {
      this.getMeetings();
   }

  ngOnInit() {
  }

  getMeetings(){
    this.meetingService.getMeetings().subscribe(data => {
      
    });
  }
}
