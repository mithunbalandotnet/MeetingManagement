import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  public login(login: Login) {
    var apiUrl = environment.apiUrl
  var url = apiUrl + 'token';
  return this.httpClient.post<any>(url, login);
}
}
