import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MeetingListComponent } from './components/meeting-list/meeting-list.component';
import { LoginComponent } from './components/login/login.component';
import { AuthorizeService as Authorize} from './services/authorize.service';


const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./home/home.module').then(mod => mod.HomeModule),
    canActivate: [Authorize]
  },
  {
    path: 'login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
