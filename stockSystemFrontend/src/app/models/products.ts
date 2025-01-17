export interface Products{
    id: number
    name: string
    description: string
    quantity: number
    originalQuantity?: number;  // Añadimos la propiedad para almacenar el valor original
    originalPrice?: number;     //
    image:string
    price: number
    userId: number
    userName: string
}

