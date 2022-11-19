import { Component, HostListener, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import * as bcrypt from 'bcryptjs';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  validators: Array<number>=[1,1,1,1,1];
  myHash!: string;

  myForm = this.form.group({
    usernameInput: ['',Validators.pattern("^[a-z0-9_-]{8,15}$")],
    passwordInput: ['',Validators.pattern("^[a-z0-9_-](?=.*[A-Z])(?!.*\s).{8,15}$")],
    RpasswordInput: ['',Validators.pattern("^[a-z0-9_-](?=.*[A-Z])(?!.*\s).{8,15}$")],
    emailInput: ['',Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$")],
    phoneInput: ['',Validators.pattern("^[0-9]{10}$")]
  });


  sendForm(){
    if(this.handleErori()==1)
      return;

    if(this.myForm.value.passwordInput==undefined)
    return;

    const salt = bcrypt.genSaltSync(10);
    this.myForm.value.passwordInput = bcrypt.hashSync(this.myForm.value.passwordInput, salt);

    console.log(this.myForm);
    // const utilizator:Utilizator = <Utilizator>{
    //   NumeUtilizator:this.formular.value.numeUtilizatorInput,
    //   Parola:this.formular.value.parolaInput,
    //   Email:this.formular.value.emailInput,
    //   Drepturi:1
    // }

    // this.uService.post(utilizator).subscribe(
    //   data => {console.log(data)},
    //   (err:HttpErrorResponse) => {
    //   });

    this.router.navigate(['/login']);
  }

  handleErori(){
    let result=0;
    let temp = this.myForm.get('usernameInput');
    if(temp?.status=='INVALID' || temp?.value == '')
      this.validators[0]=1;
    else
    {
      this.validators[0]=1;
      result=1;
    }
    temp = this.myForm.get('passwordInput');
    if(temp?.status=='INVALID' || temp?.value == '')
      this.validators[1]=1;
    else
    {
      this.validators[1]=1;
      result=1;
    }
    temp = this.myForm.get('RpasswordInput');
    if(temp?.status=='INVALID' || temp?.value == '')
      this.validators[2]=1;
    else
    {
      this.validators[2]=1;
      result=1;
    }
    temp = this.myForm.get('emailInput');
    if(temp?.status=='INVALID' || temp?.value == '')
      this.validators[3]=1;
    else
    {
      this.validators[3]=1;
      result=1;
    }
    
    if(this.myForm.get('parolaInput')==this.myForm.get('RparolaInput'))
      this.validators[3]=1;
    else
    {
      this.validators[4]=1;
      result=1;
    }
    return result;
  }

  @HostListener('document:keyup', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    if (event.key == 'Enter') {
      if(this.handleErori()==1)
        return;
      this.sendForm()
    }
  }

  constructor(
    private form: FormBuilder,
    private router: Router,) {
    }

  ngOnInit(): void {
  }
}
