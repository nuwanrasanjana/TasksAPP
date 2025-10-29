import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CustomValidators } from '../../../core/validators/custom-validators';

@Component({
  selector: 'app-register-form',
  imports: [ReactiveFormsModule,NgIf],
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.scss'
})
export class RegisterFormComponent {

  registerForm : FormGroup = new FormGroup({
    email : new FormControl('',[Validators.required,Validators.email]),
    password : new FormControl('',[Validators.required,Validators.minLength(8)]),
    resetPassword : new FormControl('',[Validators.required,Validators.minLength(8)]),
  },
{
  validators : [CustomValidators.passwordMatching()]
})

  onSubmit(){
    console.log("register form values", this.registerForm.value)
  }
}
