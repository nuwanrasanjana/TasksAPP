import { Component } from '@angular/core';
import { LoginFormComponent } from '../login-form/login-form.component';
import { RegisterFormComponent } from '../register-form/register-form.component';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-auth',
  imports: [LoginFormComponent,RegisterFormComponent,NgIf],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss'
})
export class AuthComponent {
  showLogin : boolean = true

  togleForm(){
    this.showLogin = !this.showLogin
  }

}
