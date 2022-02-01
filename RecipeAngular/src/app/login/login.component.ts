import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models/User';
import { AlertifyService } from '../service/alertify.service';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  member = new User();
  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private router: Router,) { }

  ngOnInit() {
  }

  onLogin(form: NgForm) {
    const user = this.authService.login(this.member);
    if (user) {
      this.alertify.success('Successfully logged in');
      form.reset();
      this.router.navigate(['/']);
    } else {
      this.alertify.error('User ID or password is wrong');
    }
  }

}