import { Component, OnInit, ViewChild } from '@angular/core';
import { ChildComponent } from "../child/child.component";

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements OnInit {

  // vrednost koja se prenosi u child komponentu
  parentMessage = "Hello from parent!" 

  constructor() { }

  @ViewChild(ChildComponent) child;

  // primer komunikacije child -> parent : ViewChild

  messageViewChild :string;

  ngOnInit() {
    this.messageViewChild = this.child.messageViewChild
  }
  // -----------------------------------------------------


  // primer komunikacije child -> parent : Output i EventEmitter

  messageOutput = "";

  receiveMessage($event) {
    this.messageOutput = $event
  }
  // -----------------------------------------------------

}
