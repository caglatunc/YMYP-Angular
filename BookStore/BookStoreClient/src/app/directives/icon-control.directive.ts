import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
    selector: '[iconControl]',
    standalone: true
})
export class IconControlDirective {

  constructor(
  private el: ElementRef<HTMLButtonElement>
  ) { }

@HostListener("mouseenter") mouseEnter() {
  this.el.nativeElement.children[1].classList.add("fa-bounce");
}
@HostListener("mouseleave") mouseleave() {
  this.el.nativeElement.children[1].classList.remove("fa-bounce");
}

}
