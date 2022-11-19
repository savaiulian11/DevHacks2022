import { Component, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  constructor(private appComponent:AppComponent) { 
    this.appComponent.page=1;
  }

  ngOnInit(): void {
  }

}
