import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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

  public fetchAlbum = (id: string) => {
    return this.http.get<AlbumDto>(`${this.baseUrl}/api/${ApiPaths.Albums}/${id}`);
  }
}
