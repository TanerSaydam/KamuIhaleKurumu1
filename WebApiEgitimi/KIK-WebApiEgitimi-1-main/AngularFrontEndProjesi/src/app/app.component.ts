import { HttpClient } from '@angular/common/http';
import { Component, DoCheck, OnInit } from '@angular/core';
import { RequestModel } from './models/request.model';
import { PaginationService } from './services/pagination.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  response: any;
  request: RequestModel = new RequestModel();
  pageNumbers: number[] = [];
  constructor(
    private http: HttpClient,
    private pagination: PaginationService
  ){}

  ngOnInit(): void {
    this.getAll();
  }
  
  getAll(columnName: string = "Name"){
    this.request.columnName = columnName;
    this.http.post("http://localhost:5138/api/Products/GetAll", this.request).subscribe((res:any)=> {
      this.response = res;
      this.pageNumbers = this.pagination.getPageNumbers(res);
      this.request.reverse = !this.request.reverse
      // for (let i = 0; i < res.totalPages; i++) {
      //   this.pageNumbers.push(i + 1)        
      // }
      // console.log(res);
    })
  } 

  getPage(pageNumber: number){
    this.request.pageNumber = pageNumber;
    this.getAll();
  }
}
