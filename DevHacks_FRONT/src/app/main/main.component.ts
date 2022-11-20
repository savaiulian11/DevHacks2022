import { Component, OnInit } from '@angular/core';
import { Observable, Subscription, timer } from 'rxjs';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
})
export class MainComponent implements OnInit {
  items: any = ['Static(1 Point)', 'Dinamic(1 Point)', 'Social(2 Point)'];

  workedTime: any = '00:00:00';
  ms: any = '0' + 0;
  sec: any = '0' + 0;
  min: any = '0' + 0;
  hr: any = '0' + 0;

  fullMs: any = '0' + 0;
  fullSec: any = '0' + 0;
  fullMin: any = '0' + 0;
  fullHr: any = '0' + 0;

  onlinePeople: any = ['Iulian', 'George', 'Radu'];
  activityGenerator = false;
  startTimer: any;
  running = false;
  beginActivity = false;

  start(): void {
    if (!this.running) {
      this.running = true;
      this.startTimer = setInterval(() => {
        if (this.beginActivity == false) {
          this.ms++;
          this.ms = this.ms < 10 ? '0' + this.ms : this.ms;
        }

        if (this.ms === 100 && this.beginActivity == false) {
          this.sec++;
          this.sec = this.sec < 10 ? '0' + this.sec : this.sec;
          this.ms = '0' + 0;

          if (this.sec === 60 && this.beginActivity == false) {
            this.min++;
            this.min = this.min < 10 ? '0' + this.min : this.min;
            this.sec = '0' + 0;
          }

          if (this.min === 60 && this.beginActivity == false) {
            this.hr++;
            this.hr = this.hr < 10 ? '0' + this.hr : this.hr;
            this.min = '0' + 0;
          }
        }

        if (this.beginActivity == false) {
          this.fullMs++;
          this.fullMs = this.fullMs < 10 ? '0' + this.fullMs : this.fullMs;
        }

        if (this.fullMs === 100 && this.beginActivity == false) {
          this.fullSec++;
          this.fullSec = this.fullSec < 10 ? '0' + this.fullSec : this.fullSec;
          this.fullMs = '0' + 0;

          if (this.fullSec === 60 && this.beginActivity == false) {
            this.fullMin++;
            this.fullMin =
              this.fullMin < 10 ? '0' + this.fullMin : this.fullMin;
            this.fullSec = '0' + 0;
          }

          if (this.fullMin === 60 && this.beginActivity == false) {
            this.fullHr++;
            this.fullHr = this.fullHr < 10 ? '0' + this.fullHr : this.fullHr;
            this.fullMin = '0' + 0;
          }
        }

        if (this.sec === 10 && this.beginActivity == false) {
          this.beginActivity = true;
          this.startActivity();
        }
      }, 10);
    } else {
      this.stop();
    }
  }

  stop(): void {
    clearInterval(this.startTimer);
    this.running = false;
    this.beginActivity = false;
    this.ms = '0' + 0;
    this.sec = '0' + 0;
    this.min = '0' + 0;
    this.hr = '0' + 0;
  }

  startActivity() {
    let audio = new Audio();
    audio.src = '../assets/alert.mp3';
    audio.load();
    audio.play();
    document.getElementById('activityButton')?.click();
  }

  generateActivity(){
    this.activityGenerator=true;
  }

  constructor(private appComponent: AppComponent) {
    this.appComponent.page = 1;
  }

  ngOnInit(): void {}
}
