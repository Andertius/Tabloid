import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommandResponse } from 'src/app/models/command-response.model';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { environment } from 'src/environments/environment';
import { ApiPaths } from '../enums/api-paths.enum';

@Injectable({
  providedIn: 'root',
})
export class SongService {
  constructor(private readonly http: HttpClient) {}

  public fetchSongs = () => {
    return this.http.get<SongDto[]>(
      `${environment.baseUrl}/api/${ApiPaths.Songs}`
    );
  }

  public fetchSong = (id: string) => {
    return this.http.get<SongDto>(
      `${environment.baseUrl}/api/${ApiPaths.Songs}/${id}`
    );
  }

  public setFavourite = (id: string, isFavourite: boolean) => {
    return this.http.patch<CommandResponse<SongDto>>(
      `${environment.baseUrl}/api/${ApiPaths.Songs}/${id}/is-favourite/${isFavourite}`, {}
    );
  }

  public setMastered = (id: string, isMastered: boolean) => {
    return this.http.patch<CommandResponse<SongDto>>(
      `${environment.baseUrl}/api/${ApiPaths.Songs}/${id}/is-mastered/${isMastered}`, {}
    );
  }

  public addSong = (song: SongDto) => {
    return this.http.post<CommandResponse<SongDto>>(`${environment.baseUrl}/api/${ApiPaths.Songs}`, song);
  }

  public editSong = (song: SongDto) => {
    return this.http.put<CommandResponse<SongDto>>(
      `${environment.baseUrl}/api/${ApiPaths.Songs}`,
      song
    )
  }

  public deleteSong = (id: string) => {
    return this.http.delete<CommandResponse<SongDto>>(
      `${environment.baseUrl}/api/${ApiPaths.Songs}/${id}`
    )
  }
}
