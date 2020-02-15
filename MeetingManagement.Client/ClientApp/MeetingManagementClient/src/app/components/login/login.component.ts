import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/models/login';
import { LoginService } from 'src/app/services/login.service';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  login: Login;
  constructor(private loginService: LoginService, 
    private apiService: ApiService,
    private router: Router) { 
    
  }

  ngOnInit() {
    this.login  = { password : "", userName : ""};
  }

  authenticate(){
      this.loginService.login(this.login).subscribe(data => {
        this.apiService.setHeader(data);
        this.router.navigate(['/meetings'])
      });
    
  }
}
