import { Component, inject } from '@angular/core';
import { ProductService } from '../services/products.service';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';

import {MatIconModule} from '@angular/material/icon';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-stock',
  imports: [MatCardModule,MatButtonModule,MatIconModule,CommonModule],
  templateUrl: './stock.component.html',
  styleUrl: './stock.component.css'
})
export class StockComponent {
  private readonly productSvsc = inject(ProductService)
  products$ = this.productSvsc.getProducts()
}
