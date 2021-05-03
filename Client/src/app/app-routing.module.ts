import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { WeatherComponent } from './WeatherApp/weather.component';
import { AuthGuard } from './account/auth.guard';


const routes: Routes = [
  {path: '', component: HomeComponent},

  {path: 'account',
  loadChildren: () => import('./account/account.module')
    .then(mod => mod.AccountModule)},

  {path: 'weather', canActivate: [AuthGuard], component: WeatherComponent, loadChildren: ()=> import('./WeatherApp/weather.module').then(mod => mod.WeatherModule)},
  //{path: 'weather', loadChildren: ()=> import('./WeatherApp/weather.module').then(mod => mod.WeatherModule), canActivate: [AuthGuard]},

  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]

})
export class AppRoutingModule { }
