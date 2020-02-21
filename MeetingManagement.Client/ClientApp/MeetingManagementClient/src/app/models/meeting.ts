import { Attendee } from './attendee';

export class Meeting{
 id: number;
subject: string;
meetingAgenda : string;
meetingDateTime: Date;
attendees:Array<Attendee>;
attendeesList: string;
}
