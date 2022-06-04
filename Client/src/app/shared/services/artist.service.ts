import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ArtistDto } from 'src/app/models/dtos/artist.dto';
import { environment } from '../../../environments/environment';
import { ApiPaths } from '../enums/api-paths.enum';

@Injectable({
  providedIn: 'root'
})
export class ArtistService {

  baseUrl = environment.baseUrl;

  constructor(private readonly http: HttpClient) { }

  public fetchArtists = () => {
    return this.http.get<ArtistDto[]>(`${this.baseUrl}/api/${ApiPaths.Artists}`);
  }

  public fetchArtist = (id: string) => {
    return this.http.get<ArtistDto>(`${this.baseUrl}/api/${ApiPaths.Artists}/${id}`);
  }
}
