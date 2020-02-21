import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { TokenService } from './token.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private httpOptions = {
        headers: {}
    };

  constructor(private httpClient: HttpClient,
    private tokenService: TokenService,
    private router : Router) { }
    setHeader(): boolean{
      var currentToken = this.tokenService.getToken();
      if (currentToken == null || currentToken.token == null || currentToken.token.length == 0) {
        return false;
      }
      if(currentToken.expiration < new Date()){      
        return false;
      }

      this.httpOptions.headers = new HttpHeaders({ 
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + currentToken.token
     });
      return true;
    }
  get(url:string, data:any){
    if(this.setHeader()){
    var apiUrl = environment.apiUrl
    var url = apiUrl + 'api/' + url;
    if(data != null){      
     var params = Object.entries(data).map(([key, val]) => `${key}=${val}`).join('&')
     url = url + '?' + params;
    }
    return this.httpClient.get<any>(url, this.httpOptions);
  }
  else{
    this.router.navigate(['/login']);
  }
  }

  post(url:string, data:any){
    if(this.setHeader()){
      var apiUrl = environment.apiUrl
      var url = apiUrl + 'api/' + url;
      return this.httpClient.post<any>(url, data, this.httpOptions);
    }
    else{
      this.router.navigate(['/login']);
    }
  }
}
