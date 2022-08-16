import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../Models/Category';

const options = {
  headers: new HttpHeaders()
    .set('context-type', 'application/json')
}
@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private url = '/api/category/v1/';

  constructor(private http: HttpClient) { }

  CreateCategoryRequest(request: Category): Observable<any>{
    return this.http.post<any>(this.url, request, options);
  }

  GetCategoriesRequest(): Observable<Category[]>{
    return this.http.get<Category[]>(this.url);
  }
}
