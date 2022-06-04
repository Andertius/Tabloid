import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { AlbumService } from 'src/app/shared/services/album.service';
import { StringService } from 'src/app/shared/services/string.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-album-card',
  templateUrl: './album-card.component.html',
  styleUrls: ['./album-card.component.scss']
})
export class AlbumCardComponent implements OnInit {

  album!: AlbumDto;

  constructor(
    private readonly router: Router,
    private readonly albumService: AlbumService,
    private readonly stringService: StringService) { }

  ngOnInit(): void {
    this.albumService.fetchAlbums().subscribe(x => this.album = x[0]);
  }

  getImageSource() {
    if (this.album === undefined || this.stringService.isNullOrEmpty(this.album.cover)) {
      return "../../../../assets/artist-default.png";
    }

    return `${environment.baseUrl}/album-covers/${this.album.cover}`;
  }

  goToAlbum() {
    console.log(this.album.id);
    this.router.navigate(['album', this.album.id]);
  }
}
