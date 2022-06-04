import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { ArtistService } from 'src/app/shared/services/artist.service';
import { StringService } from 'src/app/shared/services/string.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent implements OnInit {

  artist!: ArtistDto;

  constructor(
    private readonly artistService: ArtistService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router,
    private readonly stringService: StringService) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get("id");

    if (id === null) {
      this.router.navigate(['home']);
    }

    this.artistService.fetchArtist(id!)
      .subscribe(response => this.artist = response);
  }

  getImageSource() {
    if (this.artist === undefined || this.stringService.isNullOrEmpty(this.artist.image)) {
      return "../../../../assets/artist-default.png";
    }

    return `${environment.baseUrl}/artist-avatars/${this.artist.image}`;
  }

}
