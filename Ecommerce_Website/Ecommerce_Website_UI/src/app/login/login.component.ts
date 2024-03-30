import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserModel } from '../models/UserModel.model';
import { HttpClient } from '@angular/common/http';
import { Route, Router } from '@angular/router';
import { ProductsService } from '../service/products.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  public loginForm: FormGroup;
  public loginObj = new UserModel();
  constructor(private fb :FormBuilder, private http : HttpClient,private router : Router,private ps : ProductsService) { }


  ngOnInit(): void {
    this.loginForm = this.fb.group({
      fullname:["", Validators.required],
      username:["",Validators.compose([Validators.required,Validators.email])],
      password:["",Validators.required]
    });
   localStorage.clear();
  }
  login(){
  //   this.http.get<any>("http://localhost:3000/signupUsers")
  //   .subscribe(res=>{
  //     const user = res.find((a:any)=>{
  //       return a.email === this.loginForm.value.email && a.password === this.loginForm.value.password
  //     });
  //     if(user){
  //       alert("Login Success!!");
  //       this.router.navigate(['dashboard']);
  //         this.loginForm.reset();
  //     }
  //   },err=>{
  //     alert("Something went wrong!!")
  //   })
  this.loginObj.FullName = this.loginForm.value.fullname;
  this.loginObj.UserName = this.loginForm.value.username;
  this.loginObj.Password = this.loginForm.value.password;
  this.ps.login(this.loginObj)
  .subscribe(res=>{
    alert(res.message);
    this.router.navigate(['']);
    localStorage.setItem('token',res.token);
    
  },err=>{
    alert("something went wrong")
  })
   }


}
