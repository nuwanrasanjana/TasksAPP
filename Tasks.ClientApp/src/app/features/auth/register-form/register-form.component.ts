import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CustomValidators } from '../../../core/validators/custom-validators';
import { AuthService } from '../services/auth.service';
import { Register } from '../../../core/models/register.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-form',
  imports: [ReactiveFormsModule,NgIf],
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.scss'
})
export class RegisterFormComponent {

  constructor(private authService : AuthService, private router : Router){}

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
    var registerUser = {
      email : this.registerForm.value.email,
      password : this.registerForm.value.password,
      confirmPassword : this.registerForm.value.resetPassword,
    }
    this.onRegister(registerUser)
  }
  onRegister(registerUser : Register){
    this.authService.register(registerUser).subscribe(user=>{
      this.router.navigateByUrl('login')
    })
  }
}
