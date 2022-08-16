import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../Models/Product';

const options = { 
  headers: new HttpHeaders()
    .set('content-type', 'application/json')
}
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url : string = '/api/product/v1/';

  constructor(private http: HttpClient) { }

  CreateProduct(data: Product): Observable<any>{
    return this.http.post<any>(this.url, data, options);
  }
}
