import { Component } from '@angular/core';
import { Products } from '../../models/products.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from '../../service/products.service';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrl: './product-view.component.css'
})
export class ProductViewComponent {
  Products: Products = {
    id: '',
    title: '',
    price: '',
    description: '',
    category: '',
    image: '',
    rating: ''

  }

  constructor(private route: ActivatedRoute, private ps: ProductsService, private router: Router){}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id: string = params.get('id');
        if(id){
          //call api
          this.ps.getById(id).subscribe({
            next: (res) =>{
              this.Products = res;
            }
          })

        }
      }
    })
  }

}
