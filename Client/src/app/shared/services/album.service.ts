import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommandResponse } from 'src/app/models/command-response.model';
import { AlbumDto } from 'src/app/models/dtos/album.dto';
import { environment } from 'src/environments/environment';
import { ApiPaths } from '../enums/api-paths.enum';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  baseUrl = environment.baseUrl;

  constructor(private readonly http: HttpClient) { }

  public fetchAlbums = () => {
    return this.http.get<AlbumDto[]>(`${this.baseUrl}/api/${ApiPaths.Albums}`);
  }

  public fetchJustNames = () => {
    return this.http.get<AlbumDto[]>(`${this.baseUrl}/api/${ApiPaths.Albums}/just-names`);
  }

  public fetchAlbum = (id: string) => {
    return this.http.get<AlbumDto>(`${this.baseUrl}/api/${ApiPaths.Albums}/${id}`);
  }

  public addAlbum = (album: AlbumDto) => {
    return this.http.post<CommandResponse<AlbumDto>>(`${this.baseUrl}/api/${ApiPaths.Albums}`, album);
  }

  public editAlbum = (album: AlbumDto) => {
    return this.http.put<CommandResponse<AlbumDto>>(`${this.baseUrl}/api/${ApiPaths.Albums}`, album);
  }

  public uploadCover = (id: string, formData: FormData) => {
    return this.http.patch<{ fileName: string }>(`${this.baseUrl}/api/${ApiPaths.Albums}/${id}/cover`, formData);
  }
}
