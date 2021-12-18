import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment as env } from 'src/environments/environment';
import { map, Observable } from 'rxjs';
import { VehicleInfo } from '../models/VehicleInfo';
import { UserInfo } from '../models/UserInfo';
import { Transaction } from '../models/Transactions';
import { NewTransaction } from '../models/NewTransaction';
import { VehicleTransaction } from '../models/VehicleTransaction';
import { ViewVehicleComponent } from '../components/view-vehicle/view-vehicle.component';

@Injectable({
  providedIn: 'root'
})

export class HttpService {
private cars: VehicleInfo[];
private users: UserInfo[];
private user: UserInfo;
private car: VehicleInfo;
private transaction: NewTransaction;
private vehicleTransaction: VehicleTransaction;
private transactions: Transaction[];

  constructor(private http: HttpClient) { 
  this.cars = [];
  this.users = [];
  this.transactions = [];
  this.user  = {} as UserInfo;
  this.car  = {} as VehicleInfo;
  this.transaction  = {} as NewTransaction;
  this.vehicleTransaction  = {} as VehicleTransaction;
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

  getUserInfo(userID: number): Observable<UserInfo>{

    return this.http.get<UserInfo>(`${env.BASE_URL}/users/userinfo/` + userID).pipe(map(res=> this.user = res))
  }

  getVehicleInfo(vehicleID: number): Observable<VehicleInfo>{

    return this.http.get<VehicleInfo>(`${env.BASE_URL}/vehicles/getvehicleinfo/`  + vehicleID).pipe(map(res=> this.car = res))
  }

  makeTransaction(transaction: NewTransaction): Observable<VehicleTransaction>{

    return this.http.post<VehicleTransaction>(`${env.BASE_URL}/transactions/addnewtransaction`,transaction).pipe(map(res=> this.vehicleTransaction = res))
  }
}