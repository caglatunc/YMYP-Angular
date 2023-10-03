import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  name:string ="Cagla Tunc Savas";
  name2:string = "";
  names:string[] = ["A","B","C","D"]

  showName2InConsole(){
    this.name2 = this.name;
    console.log(this.name2);
  }
}
