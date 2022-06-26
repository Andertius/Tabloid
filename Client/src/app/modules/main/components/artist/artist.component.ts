import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { ImageService } from 'src/app/shared/services/image.service';
import { StringService } from 'src/app/shared/services/string.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent implements OnInit {

  artist!: ArtistDto;
  favourites: SongDto[] = [];
  mastered: SongDto[] = [];

  constructor(
    private readonly artistService: ArtistService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private readonly stringService: StringService,
    private readonly imageService: ImageService) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get("id");

    if (id === null) {
      this.router.navigate(['home']);
      return;
    }

    this.artistService.fetchArtist(id!)
      .subscribe(response => {
        this.artist = response;

        this.artist.songs.sort(this.stringService.compareNames);
        this.artist.albums.sort((x, y) => x.year - y.year);

        this.favourites = this.artist.songs.filter(x => x.isFavourite);
        this.mastered = this.artist.songs.filter(x => x.fullyMastered);
      });
  }

  whenFavourite(event: any) {
    const index = this.artist.songs.map(x => x.id).indexOf(event.value.id)
    this.artist.songs[index] = event.value
    this.favourites = this.artist.songs.filter(x => x.isFavourite);
  }

  whenMastered(event: any) {
    const index = this.artist.songs.map(x => x.id).indexOf(event.value.id)
    this.artist.songs[index] = event.value
    this.mastered = this.artist.songs.filter(x => x.fullyMastered);
  }

  getImageSource() {
    return this.imageService.getArtistImageSource(this.artist);
  }

}
