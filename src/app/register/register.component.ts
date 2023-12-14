import { Component, OnInit } from '@angular/core';
import { Register } from './register';
import { UntypedFormGroup, FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterService } from './register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  form!: UntypedFormGroup;

  constructor(protected registerService: RegisterService, private router: Router){

  }

  ngOnInit(): void {
    this.form = new FormGroup({
      userName: new FormControl("" , Validators.required),
      password: new FormControl("" , Validators.required),
      email: new FormControl("", Validators.required)
    })
  }

  onSubmit() {
    // has to invoke auth service and subscribe to auth service
     let userRequest: Register = {
      userName: this.form.controls['userName'].value,
      password: this.form.controls['password'].value,
      email: this.form.controls['email'].value
     };

     this.registerService.registerUser(userRequest).subscribe({
    next: result => {
      this.router.navigate(['/albums'])},
    error: error => {console.log(error);}
      
     });
     
    }
}
