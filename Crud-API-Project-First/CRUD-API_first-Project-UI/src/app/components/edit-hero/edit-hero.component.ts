import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SuperHero } from '../../models/super-hero';
import { SuperHeroService } from '../../services/super-hero.service';

@Component({
  selector: 'app-edit-hero',
  templateUrl: './edit-hero.component.html',
  styleUrl: './edit-hero.component.css'
})
export class EditHeroComponent implements OnInit {
  @Input() hero?: SuperHero;
  @Output() heroesUpdated = new EventEmitter<SuperHero[]>();

  constructor(private ss: SuperHeroService){}

  ngOnInit(): void {
    
  }

  updateHero(hero: SuperHero){
    this.ss.updateHero(hero).subscribe((heroes:SuperHero[]) => this.heroesUpdated.emit(heroes));
  }

  deleteHero(hero: SuperHero){
    this.ss.deleteHero(hero).subscribe((heroes:SuperHero[]) => this.heroesUpdated.emit(heroes));
  }

  createHero(hero: SuperHero){
    this.ss.createHero(hero).subscribe((heroes:SuperHero[]) => this.heroesUpdated.emit(heroes));
  }



}
