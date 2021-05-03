import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountRoutingModule } from './account-routing.module';
import { SharedModule } from '../shared/shared.module';
import { LoginSmallComponent } from './login-small/login-small.component';




@NgModule({
  declarations: [ RegisterComponent, LoginComponent, LoginSmallComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    SharedModule
  ],
  exports: [RegisterComponent, LoginComponent, LoginSmallComponent]

})
export class AccountModule { }
