import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Meeting } from '../models/meeting';

@Injectable({
  providedIn: 'root'
})
export class MeetingService {
  
  constructor(private apiService: ApiService) { }

  getMeetings(){
    return this.apiService.get("meeting/get", null)
  }

  getAttendees(){
    return this.apiService.get("meeting/getAttendees", null)
  }
}
