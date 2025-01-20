import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { ProductService } from '../../services/products.service';
import { CommonModule } from '@angular/common';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Products } from '../../models/products';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { ProductDialogComponent } from '../product-dialog/product-dialog.component';
import { MatSelectModule } from '@angular/material/select';
import { MatDialog } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatMenuModule} from '@angular/material/menu';
import {MatCheckboxModule} from '@angular/material/checkbox';
@Component({
  selector: 'app-product-table',
  imports: [CommonModule, MatTableModule, MatIconModule, MatFormFieldModule, MatInputModule, MatPaginatorModule, MatSortModule, MatButtonModule, FormsModule, MatSnackBarModule, MatTooltipModule, MatSelectModule,MatExpansionModule,MatMenuModule,MatCheckboxModule],
  templateUrl: './product-table.component.html',
  styleUrl: './product-table.component.css'
})
export default class ProductTableComponent implements OnInit, AfterViewInit {
  private snackBar = inject(MatSnackBar);
  private readonly productService = inject(ProductService)
  readonly dialog = inject(MatDialog);
  displayColumns: string[] =[]

  allColumns = [
    { id: 'Id', name: 'No.', visible: false },
    { id: 'Nombre', name: 'Nombre', visible: true },
    { id: 'Descripción', name: 'Descripción', visible: true },
    { id: 'Cantidad', name: 'Cantidad', visible: true },
    { id: 'Precio', name: 'Precio', visible: true },
    { id: 'Talla', name: 'Talla', visible: false },
    { id: 'Modelo', name: 'Modelo', visible: false },
    { id: 'Marca', name: 'Marca', visible: false },
    { id: 'Categoria', name: 'Categoría', visible: false},
    { id: 'Código de Barras', name: 'Código de Barras', visible: false },
    { id: 'Creado Por', name: 'Creado Por', visible: false },
    { id: 'Imagen', name: 'Imagen', visible: true },
    { id: 'Opciones', name: 'Opciones', visible: true }
  ];
  dataSource = new MatTableDataSource<Products>();
  isEditingEnabled = false;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;



  ngOnInit(): void {
    this.loadProducts();
    this.setDisplayColumns()
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;   
    this.dataSource.sort = this.sort

  }

  loadProducts(): void {
    this.productService.getProducts().subscribe({
      next: (products) => {
        this.dataSource.data = products.map(product => ({
          ...product,
          originalQuantity: product.quantity,
          originalPrice: product.price
        }));
      },
      error: (err) => console.error('Error fetching products:', err),
    });
  }
  enableMassEdit(): void {
    this.isEditingEnabled = true; // Activa la edición en masa
  }
  finalizeEdits(): void {
    // Recoger los productos que han sido modificados
    const modifiedProducts = this.dataSource.data.filter(product => {
      // Verifica si algún producto tiene cambios (por ejemplo, en cantidad o precio)
      return product.quantity !== product.originalQuantity || product.price !== product.originalPrice;
    });

    if (modifiedProducts.length > 0) {
      this.productService.updateProducts(modifiedProducts).subscribe({
        next: () => {
          console.log('Productos actualizados');
          this.loadProducts(); // Recarga la lista de productos después de la actualización
        },
        error: (err) => console.error('Error updating products:', err),
      });
    }
    this.isEditingEnabled = false;
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  openCreateProductDialog(): void {
    const dialogRef = this.dialog.open(ProductDialogComponent, {
      width: '80%',
      maxWidth:'600px',
      data: { product: null }
    });


  }

  openEditProductDialog(product: Products): void {
    console.log("data", product)
    const dialogRef = this.dialog.open(ProductDialogComponent, {
      width: '80%',
      maxWidth:'600px',
      height: 'auto',
      data: { product }
    });

    


  }


  setDisplayColumns() {
    this.displayColumns = this.allColumns
      .filter((column) => column.visible) // Asegúrate de que `visible` sea boolean
      .map((column) => column.id); // Asegúrate de que `id` sea un string válido
  }
}
