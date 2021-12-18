import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { VehicleInfo } from 'src/app/models/VehicleInfo';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-view-vehicle',
  templateUrl: './view-vehicle.component.html',
  styleUrls: ['./view-vehicle.component.scss']
})
export class ViewVehicleComponent implements OnInit {

  public vehicleId: number;
  public car: VehicleInfo;
  
  private loggedInUser: string;
  private loggedInUserEmail: string;
  private isAdmin: boolean;

  constructor(private httpService: HttpService, private activatedRoute: ActivatedRoute, private cookieService: CookieService, private router: Router) { 
    this.vehicleId = 0;
    this.car  = {} as VehicleInfo;
    this.isAdmin = false;

    if(this.cookieService.get('loggedInUser') != '')
    {
      this.loggedInUser = this.cookieService.get('loggedInUser');
      this.loggedInUserEmail = this.cookieService.get('loggedInUserEmail');
      if(this.loggedInUserEmail.toUpperCase() === 'ADMIN@EMAIL.COM')
      {
        this.isAdmin = true;

        if(this.cookieService.get('getVehicleInfo') != '')
        {
          this.vehicleId = Number(this.cookieService.get('getVehicleInfo'));
        }
        else
        {
          this.vehicleId = 0;
        }

        if(this.vehicleId > 0)
        {
        this.GetVehicleInfo(this.vehicleId);
        }
        else
        {
          alert('No vehicle specified :(');
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

  GetVehicleInfo(vehicleId: number): void{
     this.httpService.getVehicleInfo(vehicleId).subscribe(res => {
      this.car = res;
      console.log(res);
      console.log(this.car);
    })
  }
}
