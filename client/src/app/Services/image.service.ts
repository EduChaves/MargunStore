import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Image } from '../Models/Image';

const options = {
  headers: new HttpHeaders()
    .set('content-type', 'application/json')
}

@Injectable({
  providedIn: 'root'
})

export class ImageService {
  url = '/api/productimages/v1/';

  constructor(private http: HttpClient) { }

  CreateProductImagesRequest(request: Image[]): Observable<any>{
    return this.http.post<any>(this.url, request, options);
  }

  GetProductImagesRequest(): Observable<Image[]>{
    return this.http.get<Image[]>(this.url);
  }
}
