import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { map, Observable } from 'rxjs';
import { VehicleInfo } from '../models/VehicleInfo';
import { UserInfo } from '../models/UserInfo';
import { Transaction } from '../models/Transactions';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
private cars: VehicleInfo[];
private users: UserInfo[];
private transactions: Transaction[];
  constructor(private http: HttpClient) { 
  this.cars = [];
  this.users = [];
  this.transactions = [];
  }

  getAllVehicleInfo(): Observable<VehicleInfo[]>{

    return this.http.get<VehicleInfo[]>(`${env.BASE_URL}/vehicles/getallvehicleinfo`).pipe(map(res=> this.cars = res))
  }

  getAllUserInfo(): Observable<UserInfo[]>{

    return this.http.get<UserInfo[]>(`${env.BASE_URL}/users/getalluserinfo`).pipe(map(res=> this.users = res))
  }

  getAllTransactions(): Observable<Transaction[]>{

    return this.http.get<Transaction[]>(`${env.BASE_URL}/transactions/getTransactions`).pipe(map(res=> this.transactions = res))
  }
}