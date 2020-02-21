import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  
  constructor() { }

  addToken(currentToken){
    localStorage.setItem("token", JSON.stringify(currentToken));
  }

  getToken(): any{
    var currentTokenStr = localStorage.getItem("token");
    if(currentTokenStr != null && currentTokenStr.length > 0){
      var token = JSON.parse(currentTokenStr);
      return token;
    }
    return null;
  }

  getTokenString():string{
    var currentTokenStr = localStorage.getItem("token");
    if(currentTokenStr != null && currentTokenStr.length > 0){
      
      return currentTokenStr;
    }
    return null;
  }

  removeToken(){
    localStorage.clear();
  }
}
