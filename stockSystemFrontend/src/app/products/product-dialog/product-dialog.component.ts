import { AfterViewInit, Component, inject, Inject, OnInit } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import {MatSelectModule} from '@angular/material/select';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ProductCreateUpdate } from '../../models/create-update-product';
import { CommonModule } from '@angular/common';
import { Products } from '../../models/products';
import { ProductService } from '../../services/products.service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { CategoryService } from '../../services/category.service';

 // Modelo de datos para crear/actualizar

@Component({
  selector: 'app-product-dialog',
  imports: [    
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatSnackBarModule,
    MatSelectModule,
    MatDialogActions],
  templateUrl: './product-dialog.component.html',
  styleUrl: './product-dialog.component.css'
})
export class ProductDialogComponent implements OnInit {
private readonly productService = inject(ProductService)
private readonly categoryService = inject(CategoryService)
categories$ = this.categoryService.getCategories()
private snackBar = inject(MatSnackBar);
  productForm: FormGroup;
  file: File | null = null;
  preview: string | ArrayBuffer | null = null;
  filevalid = true;
  title: string = 'Crear Producto';
  constructor(
    public dialogRef: MatDialogRef<ProductDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public dataIncome: { product: Products },
    private fb: FormBuilder
  ) {
    this.productForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      description: ['', Validators.required],
      quantity: [0, Validators.required],
      price: [0, Validators.required],
      userId: [1, Validators.required],
      size:[null],
      brand:[null],
      model:[null],
      categoryId:[0,[Validators.required,Validators.min(1)]],
      barcode:[null],
      file: [null],
    });
    
  }
  ngOnInit(): void {

    if (this.dataIncome?.product) {
      // Establece manualmente cada valor del formulario
      this.productForm.patchValue({
        id: this.dataIncome.product.id || 0,
        name: this.dataIncome.product.name || '',
        description: this.dataIncome.product.description || '',
        quantity: this.dataIncome.product.quantity || 0,
        price: this.dataIncome.product.price || 0,
        userId: this.dataIncome.product.userId || 1,
        size:this.dataIncome.product.size ||'',
        barcode:this.dataIncome.product.barcode ||'',
        brand:this.dataIncome.product.brand ||'',
        model:this.dataIncome.product.model ||'',
        categoryId:this.dataIncome.product.categoryId || 0,
        

      });
      this.preview = this.dataIncome.product.image || null;
      if (this.dataIncome?.product?.id) {
        this.title = 'Editar Producto';
      }
    }
  }


  

  onFileChange(event: any): void {
    const file = event.target.files[0];
    if (file && file.type.startsWith('image')) {
      this.file = file;
      const reader = new FileReader();
      reader.onload = () => {
        this.preview = reader.result;
      };
      reader.readAsDataURL(file);
      this.productForm.patchValue({ file: this.file });
    } else {
      this.filevalid = false;
    }
  }

  // Cerrar el modal sin guardar
  onNoClick(): void {
    console.log("no hicee nada")
    this.dialogRef.close();
  }

  // Guardar el producto
  saveProduct(): void {
    console.log("Hola mundo")
    if (this.productForm.valid) {
      let formData = new FormData()
      if(this.productForm.value.id >0){
        formData.append('id', this.productForm.value.id)
      }
      formData.append('name', this.productForm.value.name)
      formData.append('description', this.productForm.value.description)
      formData.append('quantity', this.productForm.value.quantity+"")
      formData.append('price', this.productForm.value.price+"")
      formData.append('userId',this.productForm.value.userId+"" )
      formData.append('categoryId',this.productForm.value.categoryId+"" )
      formData.append('size',this.productForm.value.size)
      formData.append('brand',this.productForm.value.brand )
      formData.append('model',this.productForm.value.model)
      formData.append('barcode',this.productForm.value.barcode)
      if (this.file) {
        console.log(this.file)
        formData.append('file', this.file, this.file.name); // Agrega el archivo si se seleccionó uno
      }
      else{
        formData.append('image',this.dataIncome.product.image )
      }
      if(this.productForm.value.id > 0 ){
        this.productService.updateProduct(formData).subscribe(
          data => this.snackBar.open("Se Actulizo el Producto Correctamente")
        )
      
      }
      else{
        this.productService.postProduct(formData).subscribe(
          data => this.snackBar.open("Se Creo el Producto Correctamente")
        )
      }

      this.dialogRef.close(); // Aquí enviarías los datos al componente principal o a un servicio
    } else {
      // Aquí podrías mostrar un mensaje de error si el formulario no es válido
      console.log('Formulario no válido');
    }

}
}
