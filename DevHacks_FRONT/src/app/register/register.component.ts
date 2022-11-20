import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { AppComponent } from '../app.component';
import { User } from '../api/Models/User';
import { UserService } from '../api/Services/User.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  validators: Array<number> = [1, 1, 1, 1, 1];
  myHash!: string;

  myForm = this.form.group({
    usernameInput: ['', Validators.pattern('^[a-z0-9_-]{8,15}$')],
    passwordInput: [
      '',
      Validators.pattern('^[a-z0-9_-](?=.*[A-Z])(?!.*s).{8,15}$'),
    ],
    RpasswordInput: [
      '',
      Validators.pattern('^[a-z0-9_-](?=.*[A-Z])(?!.*s).{8,15}$'),
    ],
    emailInput: [
      '',
      Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$'),
    ],
    phoneInput: ['', Validators.pattern('^[0-9]{10}$')],
  });

  sendForm() {
    if (this.myForm.value.passwordInput == undefined) return;

    console.log(this.myForm);
    const utilizator:User = <User>{
      Username:this.myForm.value.usernameInput,
      Password:this.myForm.value.passwordInput,
      Email:this.myForm.value.emailInput,
      Number:this.myForm.value.phoneInput,
    }

    this.userService.post(utilizator).subscribe(
      data => {console.log(data)},
      (err:HttpErrorResponse) => {
      });

    this.router.navigate(['/login']);
  }
  @HostListener('document:keyup', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key == 'Enter') {
      this.sendForm();
    }
  }

  constructor(
    private form: FormBuilder,
    private router: Router,
    private appComponent: AppComponent,
    private userService: UserService
  ) {
    this.appComponent.page = 0;
  }

  ngOnInit(): void {}
}
