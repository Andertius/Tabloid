import { Component, OnInit } from '@angular/core';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { StringService } from 'src/app/shared/services/string.service';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.scss']
})
export class ArtistsComponent implements OnInit {

  artists: ArtistDto[] = [];

  constructor(
    private readonly artistService: ArtistService,
    private readonly stringService: StringService) { }

  ngOnInit(): void {
    this.artistService.fetchArtists()
      .subscribe(response => this.artists = response.sort(this.stringService.compareNames))
  }

}
