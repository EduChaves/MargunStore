import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../Models/Product';
import { BaseService } from './base.service';

const options = { 
  headers: new HttpHeaders()
    .set('content-type', 'application/json')
}
@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService{
  url : string = '/api/product/v1';

  constructor(private http: HttpClient) {
    super();
  }

  CreateProduct(data: Product): Observable<any>{
    return this.http.post<any>(`${this.baseUrl}${this.url}`, data, options);
  }

  GetProducts(id: number | null): Observable<Product[]> {
    const urlRequest = id != null ? `${this.url}?id=${id}` : this.url;
    return this.http.get<Product[]>(`${this.baseUrl}${urlRequest}`);
  }
}
