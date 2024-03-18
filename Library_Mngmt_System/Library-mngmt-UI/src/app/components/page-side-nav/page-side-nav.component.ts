import { Component } from '@angular/core';

export interface NavigationList {
   value: string;
   link: string;
}

@Component({
  selector: 'app-page-side-nav',
  templateUrl: './page-side-nav.component.html',
  styleUrl: './page-side-nav.component.scss'
})

export class PageSideNavComponent {
  panelName: string = "Student Panel";
  navItems:NavigationList[] = [];

  constructor(){
    this.navItems = [
      { value: 'View Books', link: 'view-book' },
      {value: 'My Orders', link: 'my-orders'}
    ]
  }


}
