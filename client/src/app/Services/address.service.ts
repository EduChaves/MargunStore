import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Address } from '../Models/Address';
import { BaseService } from './base.service';

const options = {
  headers: new HttpHeaders()
    .set('content-type', 'application/json')
}

@Injectable({
  providedIn: 'root'
})

export class AddressService extends BaseService{
  url = '/api/User/v1/address/cep';

  constructor(private http: HttpClient) { super() }

  GetCep(request: string) : Observable<Address>{
    const url = `${this.url}?request=${request}`;
    return this.http.get<Address>(`${this.baseUrl}${url}`, options);
  }
}
