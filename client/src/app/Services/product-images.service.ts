import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductImage } from '../Models/ProductImage';

const options = {
  headers: new HttpHeaders()
    .set('content-type', 'application/json')
}

@Injectable({
  providedIn: 'root'
})

export class ProductImagesService {
  url = '/api/productimages/v1/';

  constructor(private http: HttpClient) { }

  CreateProductImagesRequest(request: ProductImage[]): Observable<any>{
    return this.http.post<any>(this.url, request, options);
  }

  GetProductImagesRequest(): Observable<ProductImage[]>{
    return this.http.get<ProductImage[]>(this.url);
  }
}
