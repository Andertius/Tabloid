import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommandResponse } from 'src/app/models/command-response.model';
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

  public fetchJustNames = () => {
    return this.http.get<ArtistDto[]>(`${this.baseUrl}/api/${ApiPaths.Artists}/just-names`);
  }

  public fetchArtist = (id: string) => {
    return this.http.get<ArtistDto>(`${this.baseUrl}/api/${ApiPaths.Artists}/${id}`);
  }

  public addArtist = (artist: ArtistDto) => {
    return this.http.post<CommandResponse<ArtistDto>>(`${this.baseUrl}/api/${ApiPaths.Artists}`, artist);
  }

  public editArtist = (artist: ArtistDto) => {
    return this.http.put<CommandResponse<ArtistDto>>(`${this.baseUrl}/api/${ApiPaths.Artists}`, artist);
  }

  public uploadAvatar = (id: string, formData: FormData) => {
    return this.http.patch<{ fileName: string }>(`${this.baseUrl}/api/${ApiPaths.Artists}/${id}/avatar`, formData);
  }
}
