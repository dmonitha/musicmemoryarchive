import { Component, OnInit } from '@angular/core';
import { UntypedFormGroup, FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from './auth.service';
import { LoginRequest } from './login-request';
import { Token } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  form!: UntypedFormGroup;

  constructor(protected authService: AuthService, private router: Router){

  }

ngOnInit(): void {
  this.form = new FormGroup({
    userName: new FormControl("" , Validators.required),
    password: new FormControl("" , Validators.required)
  })
}

onSubmit() {
// has to invoke auth service and subscribe to auth service
 let loginRequest: LoginRequest = {
  userName: this.form.controls['userName'].value,
  password: this.form.controls['password'].value
 };
 this.authService.login(loginRequest).subscribe({
//printing the token to console
  next: result => {
    this.router.navigate(['/albums']),
    console.log(result.token)},
  error: error => {console.log(error);}
  
 })
 
}

}
