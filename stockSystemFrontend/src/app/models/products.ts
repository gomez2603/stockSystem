export interface Products{
    id: number
    name: string
    description: string
    quantity: number
    originalQuantity?: number;  // Añadimos la propiedad para almacenar el valor original
    originalPrice?: number;     //
    image:string
    price: number
    categoryId:number
    categoryName:string
    size:string
    brand:string
    model:string
    barcode:string
    userId: number
    userName: string
}

