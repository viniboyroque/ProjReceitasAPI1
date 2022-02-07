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
  loggedinUser: string;
  loginForm: NgForm;

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }
  
loggedin() {
    this.loggedinUser = localStorage.getItem('name');
    return this.loggedinUser;
  }
  onLogout() {
    localStorage.removeItem('name');
    localStorage.removeItem('token');
    localStorage.removeItem('id');
    this.alertify.success('Logged out Successful');
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
