import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../Models/User';
import { BaseService } from './base.service';

const options = {
  headers: new HttpHeaders()
    .set('content-type', 'application/json')
}

@Injectable({
  providedIn: 'root'
})

export class UserService extends BaseService {
  url: string = '/api/user/v1';

  constructor(private http: HttpClient) {
    super();
  }

  CreateUser(request: User): Observable<any> {
    return this.http.post(`${this.baseUrl}${this.url}/create-user`, request, options);
  }
  
  Login(request: User): Observable<any>{
    return this.http.post(`${this.baseUrl}${this.url}`, request, options);
  }
}
