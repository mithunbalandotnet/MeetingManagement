import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from '../components/home/home.component';
import { AuthorizeService as Authorize} from '../services/authorize.service';
import { MeetingListComponent } from '../components/meeting-list/meeting-list.component';
import { MeetingAddComponent } from '../components/meeting-add/meeting-add.component';
import { MeetingEditComponent } from '../components/meeting-edit/meeting-edit.component';

const homeroutes: Routes = [
    {
        path: "",
        component: HomeComponent,
        canActivate: [Authorize],
        children: [
            {
                path: "",
                component: MeetingListComponent,
                canActivate: [Authorize]
            },
            {
                path: "meetings",
                component: MeetingListComponent,
                canActivate: [Authorize]
            },
            {
                path: "addmeeting",
                component: MeetingAddComponent,
                canActivate: [Authorize]
            },
            {
                path: "editmeeting/:id",
                component: MeetingEditComponent,
                canActivate: [Authorize]
            }
        ]
    }
];

export const homeRoutingModule = RouterModule.forChild(homeroutes);