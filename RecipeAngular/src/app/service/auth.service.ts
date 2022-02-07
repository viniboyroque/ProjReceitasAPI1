import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserForLogin } from '../Interfaces/UserForLogin';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.urlPrincipal;

  constructor(private http: HttpClient) { }

  

  // Get single user
  authUser(user: User) {
      return this.http.post(this.baseUrl + '/api/Users/login', user);
    
  }

  registerUser(user: User) {
    return this.http.post(this.baseUrl + '/api/Users/register', user);
  }

}
