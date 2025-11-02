import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Login } from '../../../core/models/login.model';
import { User } from '../../../core/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  imports: [ReactiveFormsModule,NgIf],
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.scss'
})
export class LoginFormComponent {

  loggedinUser? : User;
  constructor(private authService : AuthService, private route : Router){

  }

  loginForm : FormGroup = new FormGroup({
    email : new FormControl('',[Validators.required,Validators.email]),
    password : new FormControl('',[Validators.minLength(8),Validators.required])
  })

  onSubmit(){
    console.log("login form values", this.loginForm.value)
    var user = {
      username : this.loginForm.value.email,
      password : this.loginForm.value.password
    }
    this.onLogin(user)
  }
  onLogin(loginUser: Login){
    this.authService.login(loginUser).subscribe(data => {
      this.loggedinUser = data
      console.log("logged",this.loggedinUser)
      localStorage.setItem('loggedinuser',this.loggedinUser.email)
      this.route.navigateByUrl('tasks')

    })
  }



}
