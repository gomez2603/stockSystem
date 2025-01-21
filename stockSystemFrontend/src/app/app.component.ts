import { Component, inject, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDrawer, MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';

import { CommonModule } from '@angular/common';
import { RouterOutlet, RouterLink ,RouterLinkActive, Router, RouterModule, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [CommonModule, MatCardModule, MatButtonModule, MatToolbarModule, MatSidenavModule, MatIconModule, RouterOutlet, RouterLink, RouterLinkActive,RouterModule],

  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit  {
  private router = inject(Router);
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

}

