import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { UserInfo } from 'src/app/models/UserInfo';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-view-user',
  templateUrl: './view-user.component.html',
  styleUrls: ['./view-user.component.scss']
})
export class ViewUserComponent implements OnInit {

  public userId: number;
  public user: UserInfo;
  private loggedInUser: string;
  private loggedInUserEmail: string;
  private isAdmin: boolean;

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute, private cookieService: CookieService, private router: Router) { 
    this.userId = 0;
    this.user  = {} as UserInfo;
    this.isAdmin = false;

    if(this.cookieService.get('loggedInUser') != '')
    {
      this.loggedInUser = this.cookieService.get('loggedInUser');
      this.loggedInUserEmail = this.cookieService.get('loggedInUserEmail');
      if(this.loggedInUserEmail.toUpperCase() === 'ADMIN@EMAIL.COM')
      {
        this.isAdmin = true;
        
        if(this.cookieService.get('getUserInfo') != '')
        {
          this.userId = Number(this.cookieService.get('getUserInfo'));
        }
        else
        {
          this.userId = 0;
        }

        if(this.userId > 0)
        {
        this.GetUserInfo(this.userId);
        }
        else
        {
          alert('No user specified :(');
          this.router.navigate(['viewTransactions']);
        }
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
    
  }

  GetUserInfo(userId: number): void{
     this.httpService.getUserInfo(userId).subscribe(res => {
      this.user = res;
      console.log(res);
      console.log(this.user);
    })
  }

}
