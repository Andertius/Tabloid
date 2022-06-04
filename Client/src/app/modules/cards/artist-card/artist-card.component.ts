import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { StringService } from 'src/app/shared/services/string.service';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.scss']
})
export class ArtistCardComponent implements OnInit {

  @Input() artist!: ArtistDto;

  constructor(
    private readonly artistService: ArtistService,
    private readonly router: Router,
    private readonly stringService: StringService) { }

  ngOnInit() {
    this.artistService.fetchArtists()
      .subscribe(response => this.artist = response[0])
  }

  getImageSource() {
    if (this.artist === undefined || this.stringService.isNullOrEmpty(this.artist.image)) {
      return "../../../../assets/artist-default.png";
    }

    return `${environment.baseUrl}/artist-avatars/${this.artist.image}`;
  }

  

  goToArtist() {
    console.log(this.artist.id);
    this.router.navigate(['artist', this.artist.id]);
  }

}
