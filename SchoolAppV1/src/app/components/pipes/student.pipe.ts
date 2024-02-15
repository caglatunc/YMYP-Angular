import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'student',
  standalone: true
})
export class StudentPipe implements PipeTransform {

  transform(value: any[], search:string){
    if(search == "") return value;

    return value.filter(p=> 
      p.fullName.toLowerCase().includes(search.toLowerCase()) || 
      p.studentNumber.toString().toLowerCase().includes(search) || 
      p.identityNumber.toString().toLowerCase().includes(search))
  }
}
