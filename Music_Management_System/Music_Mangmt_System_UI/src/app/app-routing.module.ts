import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusicListComponent } from './music-list/music-list.component';
import { AddMusicComponent } from './add-music/add-music.component';
import { EditMusicComponent } from './edit-music/edit-music.component';


const routes: Routes = [
{path: '', component: MusicListComponent},
{path: 'music', component: MusicListComponent},
{path: 'music/add', component: AddMusicComponent},
{path: 'music/edit/:id', component: EditMusicComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }