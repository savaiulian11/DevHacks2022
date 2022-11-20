import { Component } from '@angular/core';
import * as $ from 'jquery';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'DevHacks_FRONT';
  online: number = 3;
  page: number = 0;

  togglerClick() {
    document.getElementById('togglerButton')?.click();
  }
}
