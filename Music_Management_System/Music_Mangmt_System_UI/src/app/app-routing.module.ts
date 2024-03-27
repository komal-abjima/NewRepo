import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MusicListComponent } from './music-list/music-list.component';


const routes: Routes = [
{path: '', component: MusicListComponent},
{path: 'music', component: MusicListComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }