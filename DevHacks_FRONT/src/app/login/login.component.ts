import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  myForm = this.form.group({
    username: [''],
    password: [''],
  });

  onSubmit() {
    //this.appComponent.togglerClick();
    if (this.myForm.value.password == undefined) return;

    console.log(this.myForm.value.password);

    this.route.navigate(['/home/3']);
  }

  @HostListener('document:keyup', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key == 'Enter') {
    }
  }

  constructor(
    private form: FormBuilder,
    private route: Router,
    private appComponent: AppComponent
  ) {
    this.appComponent.page = 0;
  }
  ngOnInit(): void {}
}
