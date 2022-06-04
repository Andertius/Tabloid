import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { AlbumService } from 'src/app/shared/services/album.service';
import { StringService } from 'src/app/shared/services/string.service';
import { environment } from 'src/environments/environment';

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
    private readonly stringService: StringService) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');

    if (id === null) {
      this.router.navigate(['home']);
    }
    
    this.albumService.fetchAlbum(id!).subscribe(response => this.album = response);
  }

  getImageSource() {
    if (this.album === undefined || this.stringService.isNullOrEmpty(this.album.cover)) {
      return "../../../../assets/artist-default.png";
    }

    return `${environment.baseUrl}/artist-avatars/${this.album.cover}`;
  }
}
