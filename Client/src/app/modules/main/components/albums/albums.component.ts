import { Component, OnInit } from '@angular/core';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { AlbumService } from 'src/app/shared/services/album.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.scss']
})
export class AlbumsComponent implements OnInit {

  albums: AlbumDto[] = [];

  constructor(
    private readonly albumService: AlbumService,
    private readonly stringService: StringService) { }

  ngOnInit(): void {
    this.albumService.fetchAlbums()
      .subscribe(response => this.albums = response.sort(this.stringService.compareNames))
  }

}
