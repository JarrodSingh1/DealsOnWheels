import { HttpClient } from '@angular/common/http';
import { Input, Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpClient, private router: Router) { }

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
        this.loginForm.reset();
        this.router.navigate(['login']);
      }, err=>{
        alert("Invalid Credentials provided :(")
      });
    }
  }
  @Input() error!: string | null;

  @Output() submitEM = new EventEmitter();
}
