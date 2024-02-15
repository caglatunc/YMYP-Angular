import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'maskIdentity',
  standalone: true
})
export class MaskIdentityPipe implements PipeTransform {

  transform(identity: string): string{
    if(identity.length == 11){
      return identity.substring(0,2) + "*****" + identity.substring(9,5);
    }
    return identity;
  }

}
