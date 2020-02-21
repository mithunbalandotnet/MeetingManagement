import { Component, OnInit, OnDestroy } from '@angular/core';
import { Login } from 'src/app/models/login';
import { LoginService } from 'src/app/services/login.service';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';
import { TokenService } from 'src/app/services/token.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  login: Login;
  constructor(private loginService: LoginService, 
    private tokenService: TokenService,
    private router: Router,
    private toastr: ToastrService) { 
      this.tokenService.removeToken();
  }

  ngOnInit() {
    this.login  = new Login();
    this.login.userName="";
    this.login.password="";
  }

  authenticate(){
    if(this.validate()){
      this.loginService.login(this.login).subscribe(data => {
        this.tokenService.addToken(data);
        this.router.navigate(['/meetings']);
      },
      error => {
        this.toastr.error("Invalid login");
      });
    } 
  }
  validate():boolean{
    if(this.login.userName.length == 0){
      this.toastr.error("Please enter username");
      return false;
    }
    if(this.login.password.length == 0){
      this.toastr.error("Please enter password");
      return false;
    }
    return true;
  }
  ngOnDestroy() {
    
  }
}
