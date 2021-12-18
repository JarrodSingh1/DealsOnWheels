import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute) { 
    this.sort = '';
    this.users = [];
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
