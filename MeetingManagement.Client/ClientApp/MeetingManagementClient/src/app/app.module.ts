import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
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
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
