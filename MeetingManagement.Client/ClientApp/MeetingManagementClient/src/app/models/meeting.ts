import { Attendee } from './attendee';

export class Meeting{
 id: number;
Subject: string;
MeetingAgenda : string;
MeetingDateTime: Date;
attendees:Array<Attendee>
}
