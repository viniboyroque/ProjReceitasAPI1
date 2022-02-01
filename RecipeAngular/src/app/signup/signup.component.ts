import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../models/User';
import { UserService } from '../service/user.service';
import { AlertifyService } from '../service/alertify.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  registerationForm: FormGroup;
  user: User;
  userSubmitted: boolean;

  constructor(private fb: FormBuilder, private userService: UserService, private alertify: AlertifyService) { }

  ngOnInit() {
    // this.registerationForm = new FormGroup({
    //   userName: new FormControl(null, Validators.required),
    //   email: new FormControl(null, [Validators.required, Validators.email]),
    //   password: new FormControl(null, [Validators.required, Validators.minLength(8)]),
    //   confirmPassword: new FormControl(null, [Validators.required]),
    // }, );
    this.createRegistrationForm();
  }

  createRegistrationForm() {
    this.registerationForm = this.fb.group({
      id: [null],
      userName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required, Validators.minLength(8)]],
      confirmPassword: [null, [Validators.required]]
    },{validators: this.passwordMatchingValidator})
  }
  passwordMatchingValidator(fg: AbstractControl) {
    return fg.get('password').value === fg.get('confirmPassword').value ? null : {notmatched: true};
  }

  // ------------------------------------
  // Getter methods for all form controls
  // ------------------------------------
  get userName() {
    return this.registerationForm.get('userName') as FormControl;
  }
  get id() {
    return this.registerationForm.get('id') as FormControl;
  }
  get email() {
    return this.registerationForm.get('email') as FormControl;
  }
  get password() {
    return this.registerationForm.get('password') as FormControl;
  }
  get confirmPassword() {
    return this.registerationForm.get('confirmPassword') as FormControl;
  }
  
  // ------------------------

  onSubmit() {
    console.log(this.registerationForm.value);
    this.userSubmitted = true;
    if (this.registerationForm.valid){
      // this.user = Object.assign(this.user, this.registerationForm.value);
      this.userService.addUser(this.userData());
      this.registerationForm.reset();
      this.userSubmitted = false;
      this.alertify.success('Congrats, you are registered');
    } else {
      this.alertify.error('Kindly provide the required fields');
    }
    
  }
  
  userData(): User{
    return this.user = {
    id: this.id.value,
    userName: this.userName.value,
    email: this.email.value,
    password: this.password.value
    }
  }
}
