import { HttpErrorResponse } from '@angular/common/http';
import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../api/Services/User.service';
import { LoginWrapper } from '../api/Wrappers/LoginWrapper';
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
    if (this.myForm.value.password == undefined) return;

    const loginData: LoginWrapper = <LoginWrapper>{
      username: this.myForm.value.username,
      password: this.myForm.value.password,
    };

    this.userService.login(loginData).subscribe(
      (data) => {
        console.log(data);
        this.route.navigate(['/home/'+data.ID]);
      },
      (err: HttpErrorResponse) => {}
    );
  }

  @HostListener('document:keyup', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key == 'Enter') {
    }
  }

  constructor(
    private form: FormBuilder,
    private route: Router,
    private appComponent: AppComponent,
    private userService: UserService
  ) {
    this.appComponent.page = 0;
  }
  ngOnInit(): void {}
}
