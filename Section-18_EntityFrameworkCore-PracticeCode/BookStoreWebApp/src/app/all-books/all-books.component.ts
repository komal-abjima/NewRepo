import { Component, OnInit } from '@angular/core';
import { BookService } from '../book.service';

@Component({
  selector: 'app-all-books',
  templateUrl: './all-books.component.html',
  styleUrl: './all-books.component.css'
})
export class AllBooksComponent implements OnInit {
  public books:any;

  constructor(private bookService: BookService ){}
  ngOnInit(): void {
    this.getAllBooks();
  }
 
  private getAllBooks(){
  
    this.bookService.getBooks().subscribe(result =>{
      this.books = result;
    });
  }
}
