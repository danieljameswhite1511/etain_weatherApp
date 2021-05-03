import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import { BrowserModule } from '@angular/platform-browser';
import { LoadingInterceptor } from './interceptors/loading.inteceptors';
import { HTTP_INTERCEPTORS } from '@angular/common/http';



@NgModule({
  declarations: [TextInputComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports: [
    ReactiveFormsModule,
    TextInputComponent
  ]
})
export class SharedModule { }
