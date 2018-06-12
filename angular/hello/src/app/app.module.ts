import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HttpModule} from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientXsrfModule } from '@angular/common/http';
import { FormsModule }          from '@angular/forms';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MainComponent } from './main/main.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ClockComponent } from './clock/clock.component';
import { ContactComponent } from './contact/contact.component';
//import { ServicesComponent } from './services/signalRservice';
const routes: Routes=[
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
  },
  {
    path: "contact",
    component: ContactComponent
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
    ContactComponent
   // ServicesComponent
  
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes) 

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
