import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommandResponse } from 'src/app/models/command-response.model';
import { GenreDto } from 'src/app/models/dtos/genre.dto';
import { environment } from 'src/environments/environment';
import { ApiPaths } from '../enums/api-paths.enum';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  baseUrl = environment.baseUrl;

  constructor(private readonly http: HttpClient) { }

  public fetchGenres = () => {
    return this.http.get<GenreDto[]>(`${this.baseUrl}/api/${ApiPaths.Genres}`);
  }

  public addGenre = (genre: GenreDto) => {
    return this.http.post<CommandResponse<GenreDto>>(`${this.baseUrl}/api/${ApiPaths.Genres}`, genre);
  }

  public editGenre = (genre: GenreDto) => {
    return this.http.put<CommandResponse<GenreDto>>(`${this.baseUrl}/api/${ApiPaths.Genres}`, genre);
  }

  public deleteGenre = (id: string) => {
    return this.http.delete<CommandResponse<GenreDto>>(`${this.baseUrl}/api/${ApiPaths.Genres}/${id}`);
  }
}
