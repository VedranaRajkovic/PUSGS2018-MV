import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit {

  // vrednost se setuje iz roditeljske komponente
  @Input() childMessage: string;

  constructor() { }

  ngOnInit() {
  }

  // vrednost kojoj ce se pristupiti u parnet komponenti -> View Child
  messageViewChild: string = "Hello from child!"

}
