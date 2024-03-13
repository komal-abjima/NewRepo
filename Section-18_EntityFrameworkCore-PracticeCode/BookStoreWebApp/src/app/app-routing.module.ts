import { NgModule, resolveForwardRef } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AllBooksComponent } from './all-books/all-books.component';
import { AddBookComponent } from './add-book/add-book.component';


const appRoutes: Routes = [
 {path: 'books', component: AllBooksComponent},
 {path: 'add', component: AddBookComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}