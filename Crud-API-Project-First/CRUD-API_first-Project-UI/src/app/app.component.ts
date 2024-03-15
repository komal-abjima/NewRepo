import { Component, OnInit } from '@angular/core';
import { SuperHero } from './models/super-hero';
import { SuperHeroService } from './services/super-hero.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'CRUD-API_first-Project';
  heroes: SuperHero[];
  heroToEdit?: SuperHero;

  constructor(private ss: SuperHeroService){}
  ngOnInit(): void {
    // this.heroes = this.ss.getSuperHeroes();
    // console.log(this.heroes);
    this.ss.getSuperHeroes().subscribe((res: SuperHero[]) => {this.heroes = res} );
  }

  updateHeroList(heroes: SuperHero[]){
    this.heroes = heroes;
  }

  initNewHero(){
    this.heroToEdit = new SuperHero;
  }

  editHero(hero){
    this.heroToEdit = hero;
  }
  

  
}
