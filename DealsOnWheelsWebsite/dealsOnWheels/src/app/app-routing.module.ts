import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RedirectComponent } from './components/redirect/redirect.component';
import { SignupComponent } from './components/signup/signup.component';
import { ViewTransactionsComponent } from './components/view-transactions/view-transactions.component';
import { ViewUserComponent } from './components/view-user/view-user.component';
import { ViewUsersComponent } from './components/view-users/view-users.component';
import { ViewVehicleComponent } from './components/view-vehicle/view-vehicle.component';

const routes: Routes = [
  {path: '', redirectTo:'home', pathMatch:'full'},
  {path: 'login', component:LoginComponent},
  {path: 'signup', component:SignupComponent},
  {path: 'home', component:HomeComponent},
  {path: 'viewUsers', component:ViewUsersComponent},
  {path: 'viewTransactions', component:ViewTransactionsComponent},
  {path: 'viewUser', component:ViewUserComponent},
  {path: 'viewVehicle', component:ViewVehicleComponent},
  {path: 'redirect', component:RedirectComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
