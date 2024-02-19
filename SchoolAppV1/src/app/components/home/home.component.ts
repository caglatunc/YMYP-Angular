import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm, NgModel } from '@angular/forms';

import { ClassRoomModel } from '../../Models/class-room.model';
import { StudentModel } from '../../Models/student.model';
import { StudentPipe } from '../pipes/student.pipe';
import { HttpService } from '../../services/http.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, FormsModule, StudentPipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  classRooms: ClassRoomModel[] = [];
  students: StudentModel[] = [];

  addStudentModel:StudentModel = new StudentModel();
  updatetudentModel:StudentModel = new StudentModel();

  selectedRoomId: string = "";
  search: string = "";


  constructor(
    private http: HttpService) {
    this.getAllClassRooms();
  }

  getAllClassRooms() {
    this.http.get("ClassRooms/GetAll", (res) => {
      this.classRooms = res;

      if (this.classRooms.length > 0) {
        this.getAllStudentsByClassRoomId(this.classRooms[0].id);
        //this.selectedRoomId = this.classRooms[0].id;
      }
    });
  }

  getAllStudentsByClassRoomId(roomId: string) {
    this.selectedRoomId = roomId;
    this.http.get("Students/GetAllByClassRoomId?classRoomId=" + this.selectedRoomId, res => {
      this.students = res

      this.students = this.students.map((val) => {
        const identityNumberPart1 = val.identityNumber.substring(0, 2);
        const identityNumberPart2 = val.identityNumber.substring(val.identityNumber.length - 6, 3);

        const newHashedIdentityNumber = identityNumberPart1 + "******" + identityNumberPart2;

        val.identityNumber = newHashedIdentityNumber;

        return val;
      })

    });
  }

  // onSubmit(form: NgForm) {
  //   if (form.valid) {
  //     this.http.post("https://localhost:7234/api/Students/Create", this.student, {
  //       headers: {
  //         "Authorization": "Bearer " + this.auth.token
  //       }
  //     }).subscribe({
  //       next: (res: any) => {
  //         console.log('Öğrenci başarıyla eklendi', res);
  //         this.getAllStudentsByClassRoomId(this.selectedRoomId);
  //         form.reset();
  //         this.student = new StudentModel();
  //       },
  //       error: (err: HttpErrorResponse) => {
  //         console.error('Öğrenci eklenirken bir hata oluştu', err);
  //       }
  //     })
  //   }
  // }

  // onSubmitClassRoom(form: NgForm) {
  //   if (form.valid) {
  //     this.http.post("https://localhost:7234/api/ClassRooms/Create", this.class, {
  //       headers: {
  //         "Authorization": "Bearer " + this.auth.token
  //       }
  //     }).subscribe({
  //       next: (res: any) => {
  //         console.log('Sınıf başarıyla eklendi', res);
  //         this.getAllClassRooms();
  //         form.reset();
  //         this.class = new ClassRoomModel();
  //       },
  //       error: (err: HttpErrorResponse) => {
  //         console.error('Sınıf eklenirken bir hata oluştu', err);
  //       }
  //     })
  //   }
  // }



}
