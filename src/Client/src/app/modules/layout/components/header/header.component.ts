import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  artistDtos: ArtistDto[] = [];

  formControl!: FormControl;

  constructor() { }

  ngOnInit(): void {
    this.formControl = new FormControl('');
  }

  search() {
    
  }

}
