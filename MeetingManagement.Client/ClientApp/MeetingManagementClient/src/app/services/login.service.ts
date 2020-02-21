import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private httpOptions = {
    headers: {}
 };

  constructor(private httpClient: HttpClient) { }

  public login(login: Login) {
    var apiUrl = environment.apiUrl
  var url = apiUrl + 'token';
  this.httpOptions.headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Access-Control-Allow-Methods': 'GET, POST, DELETE, PUT'
  });
  return this.httpClient.post<any>(url, login,this.httpOptions);
}
}
