import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(public jwtHelper: JwtHelperService,
    private tokenService: TokenService) { }

  public isAuthenticated() : boolean{
    const token = this.tokenService.getTokenString();    // Check whether the token is expired and return
    // true or false
    return !this.jwtHelper.isTokenExpired(token);
}
}
