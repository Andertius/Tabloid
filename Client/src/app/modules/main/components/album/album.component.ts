import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { AlbumService } from 'src/app/shared/services/album.service';
import { ImageService } from 'src/app/shared/services/image.service';

@Component({
  selector: 'app-album',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent implements OnInit {

  album!: AlbumDto;

  constructor(
    private readonly router: Router,
    private readonly activatedRoute: ActivatedRoute,
    private readonly albumService: AlbumService,
    private readonly imageService: ImageService) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');

    if (id === null) {
      this.router.navigate(['home']);
      return;
    }
    
    this.albumService.fetchAlbum(id!).subscribe(response => {
      this.album = response;
      this.album.songs.sort((x, y) => x.songNumberInAlbum - y.songNumberInAlbum);
    });
  }

  getImageSource() {
    return this.imageService.getAlbumImageSource(this.album);
  }
}
