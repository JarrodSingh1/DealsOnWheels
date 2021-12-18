import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { NewTransaction } from 'src/app/models/NewTransaction';
import { VehicleInfo } from 'src/app/models/VehicleInfo';
import { VehicleTransaction } from 'src/app/models/VehicleTransaction';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public sort: string;
  public cars: VehicleInfo[];
  private transaction: NewTransaction;
  private vehicleTransaction: VehicleTransaction;
  private loggedIn: boolean = false;
  private loggedInEmail: string = '';

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute, private cookieService: CookieService, private router: Router) { 
    this.sort = '';
    this.cars = [];
    this.transaction  = {} as NewTransaction;
    this.vehicleTransaction  = {} as VehicleTransaction;
  }

  ngOnInit(): void {
    this.LoadAllVehicles();
  }

  LoadAllVehicles(): void{
     this.httpService.getAllVehicleInfo().subscribe(res => {
      this.cars = res;
      console.log(res);
      console.log(this.cars);
    })
  }

  BuyCar(car: VehicleInfo): void{
    console.log("buying vehicleId: " + car.vehicleId)

    this.loggedIn = false;

    if(this.cookieService.get('loggedInUser') != '')
    {
      this.loggedIn = false;
      this.loggedInEmail = this.cookieService.get('loggedInUserEmail');
      this.transaction.emailAddress = this.loggedInEmail;
      this.transaction.vehicleId = car.vehicleId;

      if(confirm("Are you sure you want to buy this car?")) {
        this.MakeTransaction();
      }
    }
    else
    {
      alert('Please log in first :)')
      this.router.navigate(['login']);
    }
  }

  MakeTransaction(): void
  {
    this.httpService.makeTransaction(this.transaction).subscribe(res => {
      this.vehicleTransaction = res;
      console.log(res);
      console.log(this.vehicleTransaction);
      alert('Congratulations on your new purchase!)')
      this.router.navigate(['redirect']);
    })
  }
}