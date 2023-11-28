import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PaginationService {

  constructor() { }

  getPageNumbers(response: any){
    const pageNumbers = [];
    let startNumber = Math.max(1,response.pageNumber - 2)
    const endNumber = Math.min(response.totalPages,response.pageNumber + 2)
    for(startNumber; startNumber <= endNumber; startNumber++){
      pageNumbers.push(startNumber);
    }

    return pageNumbers;
  }
}
