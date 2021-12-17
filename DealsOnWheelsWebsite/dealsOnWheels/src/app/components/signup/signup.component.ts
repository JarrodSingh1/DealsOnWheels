import { HttpClient} from '@angular/common/http';
import { Input, Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl} from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  private loggedInUser: string;
  private loggedInUserEmail: string;

  constructor(private http : HttpClient, private router: Router, private cookieService: CookieService) { 
    if(this.cookieService.get('loggedInUser') != '')
    {
      this.loggedInUser = this.cookieService.get('loggedInUser');
      this.loggedInUserEmail = this.cookieService.get('loggedInUserEmail');
      this.router.navigate(['login']);
    }
    else
    {
      this.loggedInUser = '';
      this.loggedInUserEmail = '';
    }
  }

  ngOnInit(): void {
  }

  signUpForm: FormGroup = new FormGroup({
    emailAddress: new FormControl(''),
    password: new FormControl(''),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    idNumber: new FormControl(''),
    phoneNumber: new FormControl(''),
    accountNumber: new FormControl(''),
    streetAddress: new FormControl(''),
    city: new FormControl(''),
    country: new FormControl(''),
    state: new FormControl(''),
    zipCode: new FormControl(''),
  });

  signUp() {
    if (this.signUpForm.valid) {
      this.submitEM.emit(this.signUpForm.value);
      this.http.post<any>("http://localhost:7152/Users/AddNewUser", this.signUpForm.value)
      .subscribe(res=> {
        alert("Account Created Successfully");
        this.cookieService.set( 'loggedInUser', 'true');
        this.cookieService.set( 'loggedInUserEmail', this.signUpForm.value.emailAddress);
        this.signUpForm.reset();
        this.router.navigate(['login']);
      }, err=>{
        alert("There was an error, Account not created :(")
      });
    }
  }
  @Input() error!: string | null;

  @Output() submitEM = new EventEmitter();
}