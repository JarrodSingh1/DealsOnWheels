import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VehicleInfo } from 'src/app/models/VehicleInfo';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public sort: string;
  public cars: VehicleInfo[];

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute) { 
    this.sort = '';
    this.cars = [];
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
    console.log("buysing vehicleId: " + car.vehicleId)
  }
}