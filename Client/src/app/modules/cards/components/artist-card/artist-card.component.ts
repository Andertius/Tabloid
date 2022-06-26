import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { ImageService } from 'src/app/shared/services/image.service';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.scss']
})
export class ArtistCardComponent {

  @Input() artist!: ArtistDto;

  constructor(
    private readonly router: Router,
    private readonly imageService: ImageService) { }

  getImageSource() {
    return this.imageService.getArtistImageSource(this.artist);
  }

  goToArtist() {
    this.router.navigate(['artist', this.artist.id]);
  }

}
