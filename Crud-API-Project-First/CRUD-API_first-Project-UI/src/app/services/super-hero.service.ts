import { Injectable } from '@angular/core';
import { SuperHero } from '../models/super-hero';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {

  private url = "SuperHero";

  constructor(private http:  HttpClient) { }
  public getSuperHeroes() : Observable<SuperHero[]>{
    // var hero = new SuperHero();
    // hero.id = 1,
    // hero.name ="Spiderman",
    // hero.firstName = "John",
    // hero.lastName = "Smith",
    // hero.place = "UK"

    // return [hero];
    return this.http.get<SuperHero[]>(`${environment.apiurl}/${this.url}`); 
  }

  public updateHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.put<SuperHero[]>(`${environment.apiurl}/${this.url}`, hero);
  } 

  
  public createHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.post<SuperHero[]>(`${environment.apiurl}/${this.url}`, hero);
  } 

  
  public deleteHero(hero: SuperHero): Observable<SuperHero[]>{
    return this.http.delete<SuperHero[]>(`${environment.apiurl}/${this.url}/${hero.id}`);
  } 
}
