import { Directive, Inject, inject, Input, OnDestroy, OnInit, TemplateRef,ViewContainerRef } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Subscription, tap } from 'rxjs';

@Directive({
  selector: '[appShowForRoles]'
})
export class ShowForRolesDirective implements OnInit {

  
@Input('appShowForRoles') allowedRoles?:string[]


   
   constructor(
    private templateRef: TemplateRef<any>,
     private ViewContainerRef: ViewContainerRef,
    private authService:AuthService
    ) {}
   ngOnInit(): void {
    this.allowedRoles.some(role => this.authService.hasRole(role))?
    this.ViewContainerRef.createEmbeddedView(this.templateRef) :
    this.ViewContainerRef.clear()
  
  }

}
