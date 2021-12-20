import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Manufacturer } from 'src/app/models/Manufacturer';
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
  public sortByManufacturer: string;
  public sortByPrice: string;
  public cars: VehicleInfo[];
  public originalCarList: VehicleInfo[];
  public manufacturers: Manufacturer[];
  private transaction: NewTransaction;
  private vehicleTransaction: VehicleTransaction;
  private loggedIn: boolean = false;
  private loggedInEmail: string = '';

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute, private cookieService: CookieService, private router: Router) { 
    this.sort = '';
    this.sortByManufacturer = '';
    this.sortByPrice = '';
    this.cars = [];
    this.originalCarList = [];
    this.manufacturers = [];
    this.transaction  = {} as NewTransaction;
    this.vehicleTransaction  = {} as VehicleTransaction;
  }

  ngOnInit(): void {
    this.LoadAllVehicles();
    this.GetAllManufacturers();
    
  }

  LoadAllVehicles(): void{
     this.httpService.getAllVehicleInfo().subscribe(res => {
      this.cars = res;
      this.originalCarList = res;
      console.log(res);
      console.log(this.cars);
    })
  }

  GetAllManufacturers(): void{
    this.httpService.getAllManufacturers().subscribe(res => {
     this.manufacturers = res.sort((a, b) => (a.manufacturerName < b.manufacturerName ? -1 : 1));;
     console.log(this.manufacturers);
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

  SortCars(sortString: string) : void
  {
    switch(sortString)
    {
      case "modelName (Low to High)" :
        this.cars.sort((a, b) => (a.modelName < b.modelName ? -1 : 1));
        console.log("sorting by modelName...");
        break;

      case "manufacturerName (Low to High)" :
        this.cars.sort((a, b) => (a.manufacturerName < b.manufacturerName ? -1 : 1));
        console.log("sorting by manufacturerName...");
        break;

      case "year (Low to High)" :
        this.cars.sort((a, b) => (a.year < b.year ? -1 : 1));
        console.log("sorting by year...");
        break;

      case "price (Low to High)" :
        this.cars.sort((a, b) => (a.price < b.price ? -1 : 1));
        console.log("sorting by price...");
        break;  

      case "fuelType (Low to High)" :
        this.cars.sort((a, b) => (a.fuelType < b.fuelType ? -1 : 1));
        console.log("sorting by fuelType...");
        break;

      case "transmission (Low to High)" :
        this.cars.sort((a, b) => (a.transmission < b.transmission ? -1 : 1));
        console.log("sorting by transmission...");
        break;

      case "displacement (Low to High)" :
        this.cars.sort((a, b) => (a.displacement < b.displacement ? -1 : 1));
        console.log("sorting by displacement...");
        break;

      case "power (Low to High)" :
        this.cars.sort((a, b) => (a.power < b.power ? -1 : 1));
        console.log("sorting by power...");
        break;  

      case "torque (Low to High)" :
        this.cars.sort((a, b) => (a.torque < b.torque ? -1 : 1));
        console.log("sorting by torque...");
        break;

      case "weight (Low to High)" :
        this.cars.sort((a, b) => (a.weight < b.weight ? -1 : 1));
        console.log("sorting by weight...");
        break;

      case "bodyType (Low to High)" :
        this.cars.sort((a, b) => (a.bodyType < b.bodyType ? -1 : 1));
        console.log("sorting by bodyType...");
        break;



        case "modelName (High to Low)" :
        this.cars.sort((a, b) => (a.modelName > b.modelName ? -1 : 1));
        console.log("sorting by modelName...");
        break;

      case "manufacturerName (High to Low)" :
        this.cars.sort((a, b) => (a.manufacturerName > b.manufacturerName ? -1 : 1));
        console.log("sorting by manufacturerName...");
        break;

      case "year (High to Low)" :
        this.cars.sort((a, b) => (a.year > b.year ? -1 : 1));
        console.log("sorting by year...");
        break;

      case "price (High to Low)" :
        this.cars.sort((a, b) => (a.price > b.price ? -1 : 1));
        console.log("sorting by price...");
        break;  

      case "fuelType (High to Low)" :
        this.cars.sort((a, b) => (a.fuelType > b.fuelType ? -1 : 1));
        console.log("sorting by fuelType...");
        break;

      case "transmission (High to Low)" :
        this.cars.sort((a, b) => (a.transmission > b.transmission ? -1 : 1));
        console.log("sorting by transmission...");
        break;

      case "displacement (High to Low)" :
        this.cars.sort((a, b) => (a.displacement > b.displacement ? -1 : 1));
        console.log("sorting by displacement...");
        break;

      case "power (High to Low)" :
        this.cars.sort((a, b) => (a.power > b.power ? -1 : 1));
        console.log("sorting by power...");
        break;  

      case "torque (High to Low)" :
        this.cars.sort((a, b) => (a.torque > b.torque ? -1 : 1));
        console.log("sorting by torque...");
        break;

      case "weight (High to Low)" :
        this.cars.sort((a, b) => (a.weight > b.weight ? -1 : 1));
        console.log("sorting by weight...");
        break;

      case "bodyType (High to Low)" :
        this.cars.sort((a, b) => (a.bodyType > b.bodyType ? -1 : 1));
        console.log("sorting by bodyType...");
        break;

      default: 
        console.log("not sorting by anything");
    }
  }

  SortByValues(): void
  {
    this.cars = this.originalCarList;

    if(this.sortByManufacturer != "Any" && this.sortByManufacturer != '')
    {
      this.cars = this.cars.filter(x => x.manufacturerName == this.sortByManufacturer);
    }

    if(this.sortByPrice != "Any" && this.sortByPrice != '')
    {
      switch(this.sortByPrice)
      {
        case "1":
          this.cars = this.cars.filter(x => x.price < 500000);
        break;
        case "2":
          this.cars = this.cars.filter(x => x.price > 500000 && x.price < 1000000);
        break;
        case "3":
          this.cars = this.cars.filter(x => x.price > 1000000 && x.price < 2000000);
        break;
        case "4":
          this.cars = this.cars.filter(x => x.price > 2000000);
        break;
        default:
        break;
      }
    }

    this.SortCars(this.sort);
  }
}