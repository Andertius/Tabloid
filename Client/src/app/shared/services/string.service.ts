import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StringService {

  constructor() { }

  isNullOrEmpty(value: string | undefined): boolean {
    return !value || value === undefined || value === "" || value.length === 0;
  }
}
