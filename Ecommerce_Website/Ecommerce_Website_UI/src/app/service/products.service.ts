import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { Products } from '../models/products.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  apiUrl: string = environment.apiURl;
  constructor(private http: HttpClient, private router: Router) { }

  getAll(): Observable<Products[]>{
    return this.http.get<Products[]>(this.apiUrl + '/api/Products');

  }

  getById(id: string): Observable<Products>{
    return this.http.get<Products>(this.apiUrl + '/api/Products' + id);

  }
}
