import { Component, OnInit } from '@angular/core';
import { Products } from '../../models/products.model';
import { ProductsService } from '../../service/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit{
  products: Products[] = [];

  constructor(private ps: ProductsService){}
ngOnInit(): void {
  this.ps.getAll().subscribe({
    next: (products) => {
      this.products = products;
    },
    error: (err)=>{
      console.log(err);
    }
  })
}
  

}
