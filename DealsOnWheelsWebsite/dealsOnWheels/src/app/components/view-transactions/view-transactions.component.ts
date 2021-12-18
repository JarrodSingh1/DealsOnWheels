import { Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from 'src/app/services/http.service';
import { Transaction } from 'src/app/models/Transactions';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-view-transactions',
  templateUrl: './view-transactions.component.html',
  styleUrls: ['./view-transactions.component.scss']
})
export class ViewTransactionsComponent implements OnInit {

  public sort: string;
  public transactions: Transaction[];
  private loggedInUser: string;
  private loggedInUserEmail: string;

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute,  private cookieService: CookieService, private router: Router) { 
    this.sort = '';
    this.transactions = [];
    this.cookieService.set( 'getUserInfo', '');
    this.cookieService.set( 'getVehicleInfo', '');

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
    this.LoadAllTransactions();
  }

  LoadAllTransactions(): void{
     this.httpService.getAllTransactions().subscribe(res => {
      this.transactions = res;
      console.log(res);
      console.log(this.transactions);
    })
  }

  ViewUser(transaction: Transaction): void{
    console.log("viewing userID: " + transaction.userId)
    this.cookieService.set( 'getUserInfo', transaction.userId + '');
    this.router.navigate(['viewUser']);
  }

  ViewVehicle(transaction: Transaction): void{
    console.log("viewing vehicleID: " + transaction.vehicleId)
    this.cookieService.set( 'getVehicleInfo', transaction.vehicleId + '');
    this.router.navigate(['viewVehicle']);
  }
}
