// Importaciones necesarias
import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { SalesDto } from '../models/salesDto';
import { SalesService } from '../services/sales.service';
import { ProductService } from '../services/products.service';
import { Products } from '../models/products';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';


@Component({
  selector: 'app-sales-product',
  standalone: true,
  imports: [
    // Angular Material modules
    MatAutocompleteModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatSnackBarModule
  ],
  templateUrl: './sales.component.html',
  styleUrl: './sales.component.css'
})
export class SalesComponent implements OnInit {
  productControl = new FormControl('');
  availableProducts: any[] = []; // Lista de productos disponibles
  selectedProducts: any[] = []; // Productos seleccionados para la venta
  filteredProducts!: Observable<any[]>;
  total = 0;

private snackBar = inject(MatSnackBar);
  private http = inject(HttpClient);
  private salesService = inject(SalesService);
    private readonly productService = inject(ProductService)

  ngOnInit() {
    this.loadProducts();
    this.filteredProducts = this.productControl.valueChanges.pipe(
      startWith(''),
      map((value) => this._filter(value || ''))
    );
  }

  loadProducts() {
    // Cargar productos desde el backend
 this.productService.getProducts().subscribe((products) => {
      this.availableProducts = products;
    });
  }

  private _filter(value: string): any[] {
    const filterValue = value.toLowerCase();
    return this.availableProducts.filter((product) =>
      product.name.toLowerCase().includes(filterValue)
  
    );
  }

  onProductSelected(event: MatAutocompleteSelectedEvent) {
    const product = event.option.value;
    this.addProduct(product);
  }

  addProduct(product: Products) {
    const existingProduct = this.selectedProducts.find(
      (p) => p.id === product.id
    );
    if (existingProduct) {
      existingProduct.quantity++;
    } else {
      this.selectedProducts.push({ ...product, quantity: 1 });
    }
    this.calculateTotal();
  }

  removeProduct(product: any) {
    this.selectedProducts = this.selectedProducts.filter(
      (p) => p.id !== product.id
    );
    this.calculateTotal();
  }

  calculateTotal() {
    this.total = this.selectedProducts
    .reduce((acc, item) => acc + item.price * item.quantity, 0);

  // Redondear a dos decimales para evitar problemas con la representación de punto flotante
  this.total = parseFloat(this.total.toFixed(2));
  }

  checkout() {
    const salesDto = {
      total: this.total,
      salesDetails: this.selectedProducts.map((p) => ({
        productId: p.id,
        quantity: p.quantity,
      })),
    };
    this.salesService.postSales(salesDto).subscribe(
      () => {
        this.selectedProducts = [];
        this.calculateTotal();
        this.snackBar.open("Venta Correcta","cerrar")
      },
      (error) => {
        console.log('Error al procesar la venta: ' , error);
        this.snackBar.open("No se puedo realizar la venta","close")
      }
    );
  }
}
