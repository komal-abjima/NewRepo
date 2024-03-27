import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusicListComponent } from './music-list/music-list.component';
import { AddMusicComponent } from './add-music/add-music.component';


const routes: Routes = [
{path: '', component: MusicListComponent},
{path: 'music', component: MusicListComponent},
{path: 'music/add', component: AddMusicComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }