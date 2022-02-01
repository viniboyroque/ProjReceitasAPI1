import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../models/User';
import { AlertifyService } from '../service/alertify.service';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  member = new User();
  showNavbar = false;
  loginbar = 'nav-login-desktop';
  loggedinUserName: string;
  loginForm: NgForm;

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
  onLogin(form: NgForm) {
    let user = this.authService.login(this.member);
    if (user){
      this.alertify.success('Successfully logged in');
      form.reset();
    } else {
      this.alertify.error('User ID or password is wrong');
    }
  }

  onLogout() {
    this.authService.logout();
    this.alertify.success('Logged out Successful')
  }

  loggedin() {
    const token = localStorage.getItem('token');
    this.loggedinUserName = token;
    return token;
  }

  onToggleNavbar() {
    this.showNavbar = !this.showNavbar;
    if (this.showNavbar) {
      this.loginbar = 'nav-login-mobile';
    } else {
      this.loginbar = 'nav-login-desktop';
    }
  }
}
