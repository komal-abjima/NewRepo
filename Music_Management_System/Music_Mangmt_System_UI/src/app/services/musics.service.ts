import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Music } from '../models/music.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MusicsService {

  apiUrl: string = environment.apiURl;
  constructor(private http: HttpClient) { }

  getAll(): Observable<Music[]>{
    return this.http.get<Music[]>(this.apiUrl + '/api/Music');
  }
}
