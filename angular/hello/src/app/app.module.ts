import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HttpModule} from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientXsrfModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MainComponent } from './main/main.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ClockComponent } from './clock/clock.component';
//import { ServicesComponent } from './services/signalRservice';
const Routes=[
  {
    path: '',
    redirectTo: "/home",
    pathMatch:'full'
  },
  {
    path: "home",
    component: HomeComponent,
  },
  {
    path: "login",
    component: LoginComponent
  },
  {
    path: "register",
    component: RegisterComponent
  }
  //{
  //  path: "services",
  //  component: ServicesComponent
 // }
  
  ]
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainComponent,
    RegisterComponent,
    LoginComponent,
    ClockComponent,
   // ServicesComponent
  
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
