import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule, MatDrawer } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterOutlet, RouterLink, RouterLinkActive, RouterModule, Router, NavigationEnd } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { ShowForRolesDirective } from '../directives/show-for-roles.directive';

@Component({
  selector: 'app-layout',
  imports: [CommonModule, MatCardModule, MatButtonModule, MatToolbarModule, MatSidenavModule, MatIconModule, RouterOutlet, RouterLink, RouterLinkActive,RouterModule,ShowForRolesDirective],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  private router = inject(Router);
  private authService  = inject(AuthService)
  showFiller = false;
  drawer!: MatDrawer;
  
  ngOnInit() {
    
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd && this.drawer) {
        this.drawer.close(); 
      }
    });
  }
  
  setDrawer(drawer: MatDrawer) {
    this.drawer = drawer;
  }
  logout(){
    this.authService.logout()
    this.router.navigate(['login']);
  }

}
