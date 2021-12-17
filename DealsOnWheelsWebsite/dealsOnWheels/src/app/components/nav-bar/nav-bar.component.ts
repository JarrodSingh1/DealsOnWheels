import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {

  isLoggedIn: boolean = false;
  loggedInUser: string = '';

  constructor(private cookieService: CookieService) {
    if(this.cookieService.get('loggedInUser') != null)
    {
      if(this.cookieService.get('loggedInUser') === 'true')
      {
        this.isLoggedIn = true;
      }
      this.loggedInUser = this.cookieService.get('loggedInUserEmail');
    }
    else
    {
      this.isLoggedIn = false;
      this.loggedInUser = '';
    }
   }

  ngOnInit(): void 
  {

  }

  ClearCookies(): void
  {
    this.cookieService.set( 'loggedInUser', '');
    this.cookieService.set( 'loggedInUserEmail', '');
    window.location.reload();
  }
}
