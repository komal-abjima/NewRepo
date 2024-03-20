import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrl: './page-header.component.scss'
})
export class PageHeaderComponent {
  loggedIn: boolean = false;
  name: string = '';
  constructor(private as: ApiService){
  as.userStatus.subscribe({
    next: (res) => {
      if (res == 'loggedIn') {
        this.loggedIn = true;
        let user = as.getUserInfo()!;
        this.name = `${user.firstName} ${user.lastName}`;
      } else {
        this.loggedIn = false;
        this.name = '';
      }
    },
  });
}

  logout(){
    this.as.logout();
  }
}
