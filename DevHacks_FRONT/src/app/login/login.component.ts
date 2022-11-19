import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import * as bcrypt from 'bcryptjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  myForm = this.form.group({
    username: [''],
    password: [''],
  });

  onSubmit() {
    if(this.myForm.value.password==undefined)
    return;

    bcrypt.hash('1234', 10, (err, hash) => {
      this.myForm.value.password = hash;
    });

    bcrypt.compare('1234',this.myForm.value.password).then(result=>{console.log(result)});


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
  ) {}

  ngOnInit(): void {
  }

}
