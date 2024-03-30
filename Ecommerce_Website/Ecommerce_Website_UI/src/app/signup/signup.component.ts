import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserModel } from '../models/UserModel.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ProductsService } from '../service/products.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  public signUpForm : FormGroup;
  public signupObj = new UserModel();
    constructor(private fb :FormBuilder, private http : HttpClient,private router : Router, private ps: ProductsService) { }

    ngOnInit(): void {
      this.signUpForm = this.fb.group({
        fullname:["", Validators.required],
        username:["",Validators.compose([Validators.required,Validators.email])],
        password:["",Validators.required],
       
      })
    }
  
    signUp(){
    //   this.http.post<any>("http://localhost:3000/signupUser", this.signUpForm.value)
    //   .subscribe(res=>{
    //     alert("Signup Successfull");
    //     this.signUpForm.reset();
    //     this.router.navigate(['login'])
    //   },err=>{
    //     alert("Something went wrong");
    //   })
    // }
    this.signupObj.FullName = this.signUpForm.value.fullname;
    this.signupObj.UserName = this.signUpForm.value.username;
    this.signupObj.Password = this.signUpForm.value.password;
   
    this.ps.signUp(this.signupObj)
    .subscribe(res=>{
      alert(res.message);
      this.signUpForm.reset();
      this.router.navigate(['login'])
    })
  }

}
