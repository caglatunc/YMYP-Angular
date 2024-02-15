import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ClassRoomModel } from '../../Models/class-room.model';
import { CommonModule } from '@angular/common';
import { StudentModel } from '../../Models/student.model';
import { StudentPipe } from '../pipes/student.pipe';
import { FormsModule, NgForm, NgModel } from '@angular/forms';
import { MaskIdentityPipe } from '../pipes/mask-identity.pipe';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, StudentPipe, FormsModule, MaskIdentityPipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  classRooms: ClassRoomModel[] = [];
  students: StudentModel[] = [];
  
  selectedRoomId: string = "";
  searchStudent: string = "";
  student: StudentModel = new StudentModel();
  class: ClassRoomModel = new ClassRoomModel();

  constructor(
    private http: HttpClient,
    private auth: AuthService) {
    this.getAllClassRooms();
  }

  getAllClassRooms() {
    this.http.get("https://localhost:7234/api/ClassRooms/GetAll", {
      headers: {
        "Authorization": "Bearer " + this.auth.token
      }
    }).subscribe({
      next: (res: any) => {
        this.classRooms = res;

        if (this.classRooms.length > 0) {
          this.getAllStudentsByClassRoomId(this.classRooms[0].id);
          //this.selectedRoomId = this.classRooms[0].id;
        }

      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    });
  }

  getAllStudentsByClassRoomId(roomId: string) {
    this.selectedRoomId = roomId;
    this.http.get("https://localhost:7234/api/Students/GetAllByClassRoomId?classRoomId=" + this.selectedRoomId, {
      headers: {
        "Authorization": "Bearer " + this.auth.token
      }
    }).subscribe({
      next: (res: any) => {
        this.students = res;
      },
      error: (err: HttpErrorResponse) => {
        console.log(err);
      }
    })
  }

  onSubmit(form: NgForm) {
    if (form.valid) {
      this.http.post("https://localhost:7234/api/Students/Create", this.student, {
        headers: {
          "Authorization": "Bearer " + this.auth.token
        }
      }).subscribe({
        next: (res: any) => {
          console.log('Öğrenci başarıyla eklendi', res);
          this.getAllStudentsByClassRoomId(this.selectedRoomId);
          form.reset();
          this.student = new StudentModel();
        },
        error: (err: HttpErrorResponse) => {
          console.error('Öğrenci eklenirken bir hata oluştu', err);
        }
      })
    }
  }

  onSubmitClassRoom(form: NgForm) {
    if (form.valid) {
      this.http.post("https://localhost:7234/api/ClassRooms/Create", this.class, {
        headers: {
          "Authorization": "Bearer " + this.auth.token
        }
      }).subscribe({
        next: (res: any) => {
          console.log('Sınıf başarıyla eklendi', res);
          this.getAllClassRooms();
          form.reset();
          this.class = new ClassRoomModel();
        },
        error: (err: HttpErrorResponse) => {
          console.error('Sınıf eklenirken bir hata oluştu', err);
        }
      })
    }
  }
}
