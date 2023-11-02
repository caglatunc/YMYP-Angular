import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SwallService } from 'src/app/services/swall.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(
    private http: HttpClient,
    private swal: SwallService,
    private router: Router
  ) { }

  signUp(form: NgForm) {
    if (form.valid) {
      this.http.post("https://localhost:7078/api/Auth/Register", {
        name: form.controls["name"].value,
        lastname: form.controls["lastname"].value,
        username: form.controls["username"].value,
        email: form.controls["email"].value,
        password: form.controls["password"].value
      }).subscribe((res:any) => {
        this.swal.callToast(res.successMessage,"success");
        this.router.navigateByUrl("/login");
      })
    }
  }
}
