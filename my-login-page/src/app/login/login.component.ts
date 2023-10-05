import { DOCUMENT } from '@angular/common';
import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
   isShowPassword: boolean = false;
   isPasswordFocus: boolean =false;

   constructor(private toastr: ToastrService){

   }

  signIn(form:NgForm){
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+\-=\[\]{};:'\\|,.<>\/?])(?=.*[0-9]).+$/;
    const str = form.controls["password"].value;
    const isValid = regex.test(str);


    if(form.valid && isValid){
      console.log(form);
      console.log(form.value);
    }else{
      this.toastr.error("Lütfen zorunlu alanları doldurun!");
    }
   
  }

  // checkValidation(el: HTMLInputElement){
  //   if(!el.validity.valid){
  //     el.classList.add("is-invalid");
  //     el.classList.remove("is-valid");
  //   }else{
  //     el.classList.remove("is-invalid");
  //     el.classList.add("is-valid");
  //   }
  // }

  showOrHidePassword(password: HTMLInputElement){
    if(this.isShowPassword){
      this.isShowPassword = false;
      password.type = "password"
    }else{
      this.isShowPassword = true;
      password.type = "text"
    }
  }

checkRegexPatternForPassword(el: HTMLInputElement){
  const text = el.value;

  //Büyük Harf Kontrolü
  const upperCaseRegex = /[A-Z]/; //Regex kontrolü yapar.
  const upperCaseResult = upperCaseRegex.test(text);// Sağlanıyorsa true, değilse false döner.
  const upperLetterEl = document.getElementById("upperLetter");
  upperLetterEl?.classList.add(upperCaseResult ? 'pw-success': 'pw-error');
  upperLetterEl?.classList.remove(!upperCaseResult ? 'pw-success': 'pw-error');

   //Küçük Harf Kontrolü
   const lowerCaseRegex = /[a-z]/;
   const lowerCaseResult = lowerCaseRegex.test(text);
   const lowerLetterEl = document.getElementById("lowerLetter");
   lowerLetterEl?.classList.add(lowerCaseResult ? 'pw-success': 'pw-error');
   lowerLetterEl?.classList.remove(!lowerCaseResult ? 'pw-success': 'pw-error');

    //Özel karakter kontrolü
    const specialCaseRegex = /[!@#$%^&*()_+\-=\[\]{};:'\\|,.<>\/?]+/;
    const specialCaseResult = specialCaseRegex.test(text);
    const specialLetterEl = document.getElementById("specialLetter");
    specialLetterEl?.classList.add(specialCaseResult ? 'pw-success': 'pw-error');
    specialLetterEl?.classList.remove(!specialCaseResult ? 'pw-success': 'pw-error');

    //Sayı kontrolü
    const numeraticCaseRegex = /[0-9]/;
    const numeraticCaseResult = numeraticCaseRegex.test(text);
    const numeraticLetterEl = document.getElementById("numeraticLetter");
    numeraticLetterEl?.classList.add(numeraticCaseResult ? 'pw-success': 'pw-error');
    numeraticLetterEl?.classList.remove(!numeraticCaseResult ? 'pw-success': 'pw-error');

    //6karakter kısmı kontrolü
    const minSixCharacterEl = document.getElementById("minSixCharacter");
    minSixCharacterEl?.classList.add(text.length < 6 ? "pw-error" : "pw-success");
    minSixCharacterEl?.classList.remove(text.length >= 6 ? "pw-error" : "pw-success");
}

}
