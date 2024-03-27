import { Component, OnInit } from '@angular/core';
import { Music } from '../models/music.model';
import { MusicsService } from '../services/musics.service';

@Component({
  selector: 'app-music-list',
  templateUrl: './music-list.component.html',
  styleUrl: './music-list.component.css'
})
export class MusicListComponent implements OnInit {
  music: Music[] = [
  // {
  //   Id:'1',
  //   Image: 'https://images.unsplash.com/photo-1619983081563-430f63602796?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8bXVzaWN8ZW58MHx8MHx8fDA%3D',
  //   SongName: 'Pehle Bhi Main',
  //   SingerName:'Vishal Mishra',
  //   ReleaseYear: 2024,
  //   MovieName: 'Animal',
  //   SongType:'Movie Song'

  // },
  // {
  //   Id:'2',
  //   Image: 'https://images.unsplash.com/photo-1619983081563-430f63602796?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8bXVzaWN8ZW58MHx8MHx8fDA%3D',
  //   SongName: 'Apna Bana Le',
  //   SingerName:'Arijit Singh',
  //   ReleaseYear: 2024,
  //   MovieName: 'Bhediya',
  //   SongType:'Movie Song'

  // },

  ];
  constructor(private ms: MusicsService){}
  ngOnInit(): void {
  this.ms.getAll().subscribe({
    next: (musics) => {
      this.music = musics;
      //console.log(musics);
    },
    error: (res) => {
      console.log(res);
    }
  })
  }

}
