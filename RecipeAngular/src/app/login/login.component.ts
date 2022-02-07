import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForLogin } from '../Interfaces/UserForLogin';
import { User } from '../models/User';
import { AlertifyService } from '../service/alertify.service';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  
  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private router: Router,) { }

  ngOnInit() {
  }

  onLogin(loginForm: NgForm) {
    console.log(loginForm.value);
    this.authService.authUser(loginForm.value).subscribe(
      (response: any) => {
        console.log(response);
        const user = response;
        localStorage.setItem('token', user.token);
        localStorage.setItem('name', user.name);
        localStorage.setItem('id', user.id);
        this.alertify.success('Successfully logged in');
        loginForm.reset();
        this.router.navigate(['/']);
        
      }, error => {
        console.log (error);
        this.alertify.error(error.error);
      }
    );

    // if (token) {
    //   localStorage.setItem('token', token.userName)
    //   this.alertify.success('Successfully logged in');
    //   loginForm.reset();
    //   this.router.navigate(['/']);
    // } else {
    //   this.alertify.error('User ID or password is wrong');
    // }
  }

}