import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './header/header.component';
import { MusicListComponent } from './music-list/music-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddMusicComponent } from './add-music/add-music.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MusicListComponent,
    AddMusicComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
