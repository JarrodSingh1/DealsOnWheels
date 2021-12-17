import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { map, Observable } from 'rxjs';
import { APIResponse } from '../models/APIResponse';
import { VehicleInfo } from '../models/VehicleInfo';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
private cars: VehicleInfo[];
  constructor(private http: HttpClient) { 
  this.cars = [];
  }

  getAllVehicleInfo(): Observable<VehicleInfo[]>{

    return this.http.get<VehicleInfo[]>(`${env.BASE_URL}/vehicles/getallvehicleinfo`).pipe(map(res=> this.cars = res))
  }
}
