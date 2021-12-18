import { Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpService } from 'src/app/services/http.service';
import { Transaction } from 'src/app/models/Transactions';

@Component({
  selector: 'app-view-transactions',
  templateUrl: './view-transactions.component.html',
  styleUrls: ['./view-transactions.component.scss']
})
export class ViewTransactionsComponent implements OnInit {

  public sort: string;
  public transactions: Transaction[];

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute) { 
    this.sort = '';
    this.transactions = [];
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
  }

  ViewVehicle(transaction: Transaction): void{
    console.log("viewing vehicleID: " + transaction.vehicleId)
  }

}
