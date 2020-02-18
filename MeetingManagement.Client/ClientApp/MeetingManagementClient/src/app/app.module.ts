import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';

import { AppComponent } from './app.component';
import { JwtModule } from '@auth0/angular-jwt';
import { LoginComponent } from './components/login/login.component';
import { MeetingListComponent } from './components/meeting-list/meeting-list.component';
import { MeetingAddComponent } from './components/meeting-add/meeting-add.component';
import { MeetingEditComponent } from './components/meeting-edit/meeting-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MeetingListComponent,
    MeetingAddComponent,
    MeetingEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    AngularMultiSelectModule,
    JwtModule.forRoot({ config: {}}),
    NgbModule
  ],
  exports:[
    LoginComponent,
    MeetingListComponent,
    MeetingAddComponent,
    MeetingEditComponent
  ],
  providers: [AngularMultiSelectModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
