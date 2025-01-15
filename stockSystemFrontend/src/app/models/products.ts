export interface Products{
    id: number
    name: string
    description: string
    quantity: number
    image:string
    price: number
    userId: number
    userName: string
}

export interface Product_Create_update{
    id: number
    name: string
    description: string
    quantity: number
    image:File
    price: number
    userId: number
   
}