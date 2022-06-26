import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AlbumDto } from "src/app/models/dtos/album.dto";
import { ArtistDto } from "src/app/models/dtos/artist.dto";
import { environment } from "src/environments/environment";
import { StringService } from "./string.service";

@Injectable({
    providedIn: 'root'
})
export class ImageService {
  baseUrl = environment.baseUrl;

  constructor(
    private readonly stringService: StringService) { }

  getArtistImageSource(artist: ArtistDto) {
    if (artist === undefined || this.stringService.isNullOrEmpty(artist.image)) {
      return "../../../../assets/artist-default.png";
    }

    return `${environment.baseUrl}/artist-avatars/${artist.image}`;
  }

  getAlbumImageSource(album: AlbumDto) {
    if (album === undefined || this.stringService.isNullOrEmpty(album.cover)) {
      return "../../../../assets/album-default.png";
    }

    return `${environment.baseUrl}/album-covers/${album.cover}`;
  }
}
