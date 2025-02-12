import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { Sale } from '../models/sales-details';
import { SalesService } from '../services/sales.service';

@Component({
  selector: 'app-sales-details',
  imports: [CommonModule, MatExpansionModule, MatTableModule],
  templateUrl: './sales-details.component.html',
  styleUrl: './sales-details.component.css'
})
export class SalesDetailsComponent implements OnInit  {
  
    private salesService = inject(SalesService);
  sales: Sale[] = [];
  displayedColumns: string[] = ['image','productName','quantity', 'productPrice'];

  ngOnInit() {
    this.salesService.getSales().subscribe(data => this.sales = data);
  }
}
