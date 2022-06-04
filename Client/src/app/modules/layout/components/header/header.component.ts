import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { ArtistService } from 'src/app/shared/services/artist.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  artistDtos: ArtistDto[] = [];

  formControl!: FormControl;

  constructor(private readonly artistService: ArtistService) { }

  ngOnInit(): void {
    this.formControl = new FormControl('');
  }

  search() {
    this.artistService.fetchArtists().subscribe(response => { this.artistDtos = response; })
  }

}
