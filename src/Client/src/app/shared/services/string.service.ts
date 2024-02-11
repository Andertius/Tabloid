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
  
  compareNamesRemoveArticles(left: {name: string}, right: {name: string}) {
    let newLeft: string;
    let newRight: string;

    if (left.name.toLowerCase().startsWith("the ") ||
        left.name.toLowerCase().startsWith("a ") ||
        left.name.toLowerCase().startsWith("an ")) {
      const index = left.name.indexOf(" ");
      newLeft = left.name.split('').filter((_, i) => i > index).join('');
    } else {
      newLeft = left.name;
    }

    if (right.name.toLowerCase().startsWith("the ") ||
        right.name.toLowerCase().startsWith("a ") ||
        right.name.toLowerCase().startsWith("an ")) {
      const index = right.name.indexOf(" ");
      newRight = right.name.split('').filter((_, i) => i > index).join('');
    } else {
      newRight = right.name;
    }

    if (newLeft > newRight) {
      return 1
    } else if (newLeft < newRight) {
      return -1
    } else {
      return 0
    }
  }
}
