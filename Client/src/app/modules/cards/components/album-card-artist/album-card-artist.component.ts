import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { ImageService } from 'src/app/shared/services/image.service';

@Component({
  selector: 'app-album-card-artist',
  templateUrl: './album-card-artist.component.html',
  styleUrls: ['./album-card-artist.component.scss']
})
export class AlbumCardArtistComponent {

  @Input() album!: AlbumDto;

  constructor(
    private readonly router: Router,
    private readonly imageService: ImageService) { }

  getImageSource() {
    return this.imageService.getAlbumImageSource(this.album);
  }

  goToAlbum() {
    this.router.navigate(['album', this.album.id]);
  }
}
