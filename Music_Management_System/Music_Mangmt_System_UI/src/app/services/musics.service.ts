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

  addMusic(addNewMusic: Music): Observable<Music> {
    return this.http.post<Music>(this.apiUrl + '/api/Music', addNewMusic);
  }

  getMusicById(id: string):Observable<Music>{
    return this.http.get<Music>(this.apiUrl + '/api/Music/'+ id);
  }

  updateMusic(id: string, updateMusic: Music): Observable<Music>{
    return this.http.put<Music>(this.apiUrl + '/api/Music/'+ id, updateMusic);
  }
  delete(id:string):Observable<Music>{
    return this.http.delete<Music>(this.apiUrl + '/api/Music/'+ id);
  }
}
