import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './components/products/products.component';
import { ProductViewComponent } from './components/product-view/product-view.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';



const routes: Routes = [
{path:'', component: ProductsComponent},
{path: 'Products/:id', component: ProductViewComponent},
{path: 'login', component: LoginComponent},
{path: 'signup', component:SignupComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }