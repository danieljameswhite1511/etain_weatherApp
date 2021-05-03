import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home.component';
import { AccountModule } from '../account/account.module';
import { AccountRoutingModule } from '../account/account-routing.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SharedModule

  ]
})
export class HomeModule { }
