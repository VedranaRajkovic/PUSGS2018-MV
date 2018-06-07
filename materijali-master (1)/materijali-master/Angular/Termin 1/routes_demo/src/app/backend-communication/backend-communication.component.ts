import { Component, OnInit } from '@angular/core';
import { DemoService } from '../services/demo.service';
import { MethodResult } from '../models/methodResult.model';

@Component({
  selector: 'app-backend-communication',
  templateUrl: './backend-communication.component.html',
  styleUrls: ['./backend-communication.component.css'],
  providers: [DemoService]
})
export class BackendCommunicationComponent implements OnInit {

  private methodResult: MethodResult;

  constructor(private demoService: DemoService) { }

  ngOnInit() {
  }

  callGet(){
    this.demoService.getMethodDemo()
      .subscribe(
        data => {
          this.methodResult = data;
          alert("GET: id: " + this.methodResult.id + ", userId: " + this.methodResult.userId + ", title: " + this.methodResult.title + ", body: " + this.methodResult.body);
        },
        error => {
          console.log(error);
        })
  }

  callPost(){
    let newMember = {
      title: 'foo',
      body: 'bar',
      userId: 1
    };

    this.demoService.postMethodDemo(newMember)
    .subscribe(
      data => {
        this.methodResult = data;
        alert("POST: id: " + this.methodResult.id + ", userId: " + this.methodResult.userId + ", title: " + this.methodResult.title + ", body: " + this.methodResult.body);
      },
      error => {
        console.log(error);
      })
  }

}
