import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BookService } from '../book.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent implements OnInit{
  public bookform:FormGroup;
  constructor(private formbuilder: FormBuilder, private bs: BookService){}
  ngOnInit(): void {
    this.init();
  }
  public SaveBook(){
    this.bs.addBook(this.bookform.value).subscribe(res =>{
    alert(`New book Added with id ${res}`)
    });
  }

  private init():void{
    this.bookform = this.formbuilder.group({
      title: [],
      description: []
    })
  }



}
