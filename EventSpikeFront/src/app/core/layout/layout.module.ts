import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from 'src/app/features/home/home.component';
import { LoginComponent } from 'src/app/features/login/login.component';
import { HomeModule } from 'src/app/features/home/home.module';
import { LoginModule } from 'src/app/features/login/login.module';



@NgModule({
  declarations: [
    LayoutComponent
  ],
  imports: [
    CommonModule,
    HomeModule,
    LoginModule,
    RouterModule
  ],
  exports: [
    LayoutComponent
  ]
})
export class LayoutModule { }
