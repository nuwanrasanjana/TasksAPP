import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../../../core/models/user.model';
import { ApiEndpoints } from '../../../core/config/api-endpoints';
import { Observable } from 'rxjs';
import { Login } from '../../../core/models/login.model';
import { Register } from '../../../core/models/register.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiURL = ApiEndpoints.USERS

  constructor(private http : HttpClient) { }

  public login(login : Login) : Observable<User>{
    const url = `${this.apiURL}/login`
    return this.http.post<User>(url,login)
  }
  public register(registerUser : Register) : Observable<User>{
    const url = `${this.apiURL}/register`
    return this.http.post<User>(url,registerUser)
  }
}
