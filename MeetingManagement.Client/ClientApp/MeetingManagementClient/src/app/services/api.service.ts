import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private httpOptions = {
        headers: {}
    };

  constructor(private httpClient: HttpClient) { }
    setHeader(header:any){
      this.httpOptions.headers = header;
    }
  get(url:string, data:any){
    var apiUrl = environment.apiUrl
    var url = apiUrl + url;
    return this.httpClient.get<any>(apiUrl, this.httpOptions.headers);
  }

  post(url:string, data:any){
    var apiUrl = environment.apiUrl
    var url = apiUrl + url;
    return this.httpClient.post<any>(apiUrl, this.httpOptions.headers);
  }
}
