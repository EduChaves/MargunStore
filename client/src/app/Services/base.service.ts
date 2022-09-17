import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BaseService {
  baseUrl = "http://localhost:5050";

  constructor(){}
}
