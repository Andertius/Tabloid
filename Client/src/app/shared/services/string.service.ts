import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StringService {

  constructor() { }

  isNullOrEmpty(value: string | undefined): boolean {
    return !value || value === undefined || value === "" || value.length === 0;
  }
  
  compareNames(left: {name: string}, right: {name: string}) {
    if (left.name > right.name) {
      return 1
    } else if (left.name < right.name) {
      return -1
    } else {
      return 0
    }
  }
}
