import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Meeting } from '../models/meeting';

@Injectable({
  providedIn: 'root'
})
export class MeetingService {
  getAttendeeReport() {
    return this.apiService.get("meeting/getattendeereport", null)
  }
  
  constructor(private apiService: ApiService) { }

  getMeetings(){
    return this.apiService.get("meeting/get", null)
  }

  getAttendees(){
    return this.apiService.get("meeting/getAttendees", null)
  }

  deleteMeeting(id: any) {
    var deleteModel = { id: id};
    return this.apiService.post("meeting/delete", deleteModel);
  }
}
