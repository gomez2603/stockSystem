import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { ProductService } from '../products.service';


@Component({
  selector: 'app-products',
  imports: [ReactiveFormsModule,MatFormFieldModule,MatIconModule,MatInputModule,CommonModule,MatButtonModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
private readonly productSvsc = inject(ProductService)
  file:File
  filevalid:boolean = true
  preview:string =""


readonly prodcutForm = new FormGroup({
    id: new FormControl(0),
    Name: new FormControl('',Validators.required),
    Description : new FormControl('',Validators.required),
    Quantity : new FormControl(null,Validators.required),
    Price : new FormControl(null,Validators.required),
    userId: new FormControl(1,Validators.required),
    file: new FormControl()
  })

async getFile(event:any){
  if(event.target.files[0].type.startsWith('image')){
    this.file = event.target.files[0]
  
   this.preview = await this.fileReader(this.file)

  }
  else{
    this.filevalid = false
    this.file = undefined
  }
  
}

fileReader(file:File):Promise<string>{
return new Promise((resolve,reject)=>{
  const reader = new FileReader();
  reader.onload = () =>{
    if(typeof reader.result === 'string'){
      resolve(reader.result);
    }else{
      console.log(reader.result)
       reject(new Error('Failed to load File'))
    }
   
  }
  reader.onerror = (error) => reject(error)
  reader.readAsDataURL(file)
})
}

createProduct(){
  let data = new FormData()
  data.append('Name', this.prodcutForm.value.Name)
  data.append('Description', this.prodcutForm.value.Description)
  data.append('Quantity', this.prodcutForm.value.Quantity)
  data.append('Price', this.prodcutForm.value.Price)
  data.append('userId',this.prodcutForm.value.userId+"" )
  data.append("file",this.file,this.file.name)
console.log("intenta crear")
  this.productSvsc.postProduct(data).subscribe((data)=>{
    console.log(data)
  })
}

}


