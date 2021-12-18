import { HttpClient } from '@angular/common/http';
import { Input, Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private loggedInUser: string;
  private loggedInUserEmail: string;

  constructor(private http: HttpClient, private router: Router, private cookieService: CookieService) {
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
        this.cookieService.set( 'isAdmin', 'false');
      }

      this.router.navigate(['home']);
    }
    else
    {
      this.loggedInUser = '';
      this.loggedInUserEmail = '';
    }
   }

  ngOnInit(): void {
    
  }

  loginForm: FormGroup = new FormGroup({
    emailAddress: new FormControl(''),
    password: new FormControl(''),
  });

  Login() {
    if (this.loginForm.valid) {
      this.submitEM.emit(this.loginForm.value);
      this.http.post<any>("http://localhost:7152/Users/Login", this.loginForm.value)
      .subscribe(res=> {
        alert("Log in Successful :)");
        this.cookieService.set( 'loggedInUser', 'true');
        this.cookieService.set( 'loggedInUserEmail', this.loginForm.value.emailAddress);
        if(this.loginForm.value.emailAddress.toUpperCase() === 'ADMIN@EMAIL.COM')
        {
          this.cookieService.set( 'isAdmin', 'true');
        }
        else
        {
          this.cookieService.set( 'isAdmin', 'false');
        }
        window.location.reload();
      }, err=>{
        alert("Invalid Credentials provided :(")
      });
    }
  }
  @Input() error!: string | null;

  @Output() submitEM = new EventEmitter();
}