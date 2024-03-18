import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { MatSnackBar, MatSnackBarRef } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  RegisterForm: FormGroup;
  hidepwd:boolean = true;
  constructor(private fb: FormBuilder, private apis: ApiService, private snakebar: MatSnackBar){
    this.RegisterForm = fb.group({
      firstname:fb.control('', [Validators.required]),
      lastname: fb.control('', [Validators.required]),
      email: fb.control('', [Validators.required]),
      mobile: fb.control('', [Validators.required]),
      password: fb.control('', [Validators.required]),
      rpassword: fb.control('', [Validators.required])
    });
  }

  register(){
    let user = {
      firstname:this.RegisterForm.get('firstname')?.value,
      lastname:this.RegisterForm.get('lastname')?.value,
      email:this.RegisterForm.get('email')?.value,
      mobile:this.RegisterForm.get('mobile')?.value,
      password:this.RegisterForm.get('password')?.value,
      

    };
    this.apis.register(user).subscribe({
      next: (res) => {
        this.snakebar.open(res, 'Ok');
      }
    })
  }

}
