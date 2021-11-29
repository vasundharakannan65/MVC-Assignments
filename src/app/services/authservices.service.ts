import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthservicesService {

  constructor(private http : HttpClient) { }

  login(data: any) : Observable<any>{
    return this.http.post(`${baseUrl}Account/Login`,data);
  }
}
