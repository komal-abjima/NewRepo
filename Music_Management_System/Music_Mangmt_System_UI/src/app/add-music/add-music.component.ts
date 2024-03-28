import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MusicsService } from '../services/musics.service';
import { Music } from '../models/music.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-music',
  templateUrl: './add-music.component.html',
  styleUrl: './add-music.component.css'
})
export class AddMusicComponent implements OnInit {
  
  public addMusicForm !: FormGroup;
  public Musicobj = new Music();
    constructor(private fb :FormBuilder, private http : HttpClient,private router : Router, private api: MusicsService) { }

    ngOnInit(): void {
      this.addMusicForm = this.fb.group({
        
        songName:["", Validators.required],
        singerName:["",Validators.required],
        releaseYear:["",Validators.compose([Validators.required,Validators.email])],
        movieName:["",Validators.required],
        songType:["",Validators.required]
      })
    }
  
    add(){
   
    this.Musicobj.songName = this.addMusicForm.value.songName;
    this.Musicobj.singerName = this.addMusicForm.value.singerName;
    this.Musicobj.releaseYear = this.addMusicForm.value.releaseYear;
    this.Musicobj.movieName = this.addMusicForm.value.movieName;
    this.Musicobj.songType = this.addMusicForm.value.songType
    this.api.addMusic(this.Musicobj)
    .subscribe(res=>{
      alert("Music added successfully.");
      this.addMusicForm.reset();
      this.router.navigate(['music'])
    })
  }


}
