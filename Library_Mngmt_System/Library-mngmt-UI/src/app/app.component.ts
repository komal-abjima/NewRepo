import { Component, OnInit } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'Library-mngmt-UI';

  constructor(private as:  ApiService){}

  ngOnInit(): void {
    let status = this.as.isLoggedIn() ? "LoggedIn" : "LoggedOff";
    this.as.userStatus.next(status);
    
  }
}
