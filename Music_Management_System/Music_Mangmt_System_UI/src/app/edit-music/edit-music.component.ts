import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MusicsService } from '../services/musics.service';
import { Music } from '../models/music.model';

@Component({
  selector: 'app-edit-music',
  templateUrl: './edit-music.component.html',
  styleUrl: './edit-music.component.css'
})
export class EditMusicComponent implements OnInit{

  MusicDetails: Music = {
    id: '',
    image: '',
    songName: '',
    singerName: '',
    releaseYear: 0,
    movieName: '',
    songType: ''
  }

  constructor(private route: ActivatedRoute, private ms: MusicsService, private router: Router){}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id: string = params.get('id');
        if(id){
          //call api
          this.ms.getMusicById(id).subscribe({
            next: (res) =>{
              this.MusicDetails = res;
            }
          })

        }
      }
    })
  }

  update(){
    this.ms.updateMusic(this.MusicDetails.id, this.MusicDetails).subscribe({
      next:(res) =>{
        this.router.navigate(['music']);
      }
    });
  }

  delete(id: string){
    this.ms.delete(id).subscribe({
      next:(res) =>{
        this.router.navigate(['music']);
      }
    })
  }

}
