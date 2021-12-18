import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { UserInfo } from 'src/app/models/UserInfo';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-view-users',
  templateUrl: './view-users.component.html',
  styleUrls: ['./view-users.component.scss']
})
export class ViewUsersComponent implements OnInit {
  
  public sort: string;
  public users: UserInfo[];
  private loggedInUser: string;
  private loggedInUserEmail: string;

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute,  private cookieService: CookieService, private router: Router) { 
    this.sort = '';
    this.users = [];

    if(this.cookieService.get('loggedInUser') != '')
    {
      this.loggedInUser = this.cookieService.get('loggedInUser');
      this.loggedInUserEmail = this.cookieService.get('loggedInUserEmail');
      if(this.loggedInUserEmail.toUpperCase() === 'ADMIN@EMAIL.COM')
      {
        this.cookieService.set( 'isAdmin', 'true');
      }
      else
      {
        this.router.navigate(['home']);
        this.cookieService.set( 'isAdmin', 'false');
      }
    }
    else
    {
      this.loggedInUser = '';
      this.loggedInUserEmail = '';
      this.router.navigate(['home']);
    }
  }

  ngOnInit(): void {
    this.LoadAllUsers();
  }

  LoadAllUsers(): void{
     this.httpService.getAllUserInfo().subscribe(res => {
      this.users = res;
      console.log(res);
      console.log(this.users);
    })
  }
}
