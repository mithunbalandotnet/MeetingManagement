import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private httpOptions = {
        headers: {}
    };

  constructor(private httpClient: HttpClient) { }

  public login(username:string, password:string) : string {
  apiUrl:string = `${environment.apiUrl}/token`;
  this.httpClient.get<any>(apiUrl, this.httpOptions);
}
}
