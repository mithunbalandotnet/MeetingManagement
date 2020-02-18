import { Component, OnInit, OnDestroy } from '@angular/core';
import { Meeting } from 'src/app/models/meeting';
import { Attendee } from 'src/app/models/attendee';
import { MeetingService } from 'src/app/services/meeting.service';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-meeting-add',
  templateUrl: './meeting-add.component.html',
  styleUrls: ['./meeting-add.component.scss']
})
export class MeetingAddComponent implements OnInit, OnDestroy {
  meeting:Meeting;
  attendeesGlobal:Array<any>;
  selectedAttendees: Array<any>;
  constructor(private meetingService: MeetingService,
    private apiService: ApiService,
    private router: Router) { }

  ngOnInit() {
    this.getAttendees();
  }

  getAttendees(){
    this.meetingService.getAttendees().subscribe(data => {
      this.attendeesGlobal = data.map(function(a){ return { id : a.id, itemName: a.name}; });  
    });
  }

  SaveClick(e){
    this.apiService.post("meeting\add", this.meeting).subscribe(data => {
      this.router.navigate(['/meetings'])
    });
  }

  ngOnDestroy(): void {
    
  }
}
