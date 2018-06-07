import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientXsrfModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { Child1Component } from './child1/child1.component';
import { Child2Component } from './child2/child2.component';
import { AboutComponent } from './about/about.component';
import { BackendCommunicationComponent } from './backend-communication/backend-communication.component';

const ChildRoutes =
  [
    {
      path: "child1",
      component: Child1Component
    },
    {
      path: "child2",
      component: Child2Component
    }
  ]

const Routes = [
  {
    path: "home",
    component: HomeComponent,
    children: ChildRoutes
  },
  {
    path: "about/:Id",
    component: AboutComponent
  },
  {
    path: "communication",
    component: BackendCommunicationComponent
  },
  {
    path: "other",
    redirectTo: "home"
  }
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    Child1Component,
    Child2Component,
    AboutComponent,
    BackendCommunicationComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(Routes),
    HttpModule,
    HttpClientModule,
    HttpClientXsrfModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
