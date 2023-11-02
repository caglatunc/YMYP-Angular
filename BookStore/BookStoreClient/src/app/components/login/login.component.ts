import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(
    private http: HttpClient,
    private router:Router
  ){

  }
  signIn(form: NgForm){ 
if(form.valid){
  this.http.post("https://localhost:7078/api/Auth/Login",{ usernameOrEmail:form.controls["usernameOrEmail"].value, password: form.controls["password"].value})
  .subscribe((res:any)=> {
    console.log(res);
    localStorage.setItem("response",JSON.stringify(res));
    this.router.navigateByUrl("/");
  })
}
  }
}
