import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommandResponse } from 'src/app/models/command-response.model';
import { TuningDto } from 'src/app/models/dtos/tuning.dto';
import { environment } from 'src/environments/environment';
import { ApiPaths } from '../enums/api-paths.enum';

@Injectable({
  providedIn: 'root'
})
export class TuningService {

  baseUrl = environment.baseUrl;

  constructor(private readonly http: HttpClient) { }

  public fetchTunings = () => {
    return this.http.get<TuningDto[]>(`${this.baseUrl}/api/${ApiPaths.Tunings}`);
  }

  public addTuning = (genre: TuningDto) => {
    return this.http.post<CommandResponse<TuningDto>>(`${this.baseUrl}/api/${ApiPaths.Tunings}`, genre);
  }

  public editTuning = (genre: TuningDto) => {
    return this.http.put<CommandResponse<TuningDto>>(`${this.baseUrl}/api/${ApiPaths.Tunings}`, genre);
  }

  public deleteTuning = (id: string) => {
    return this.http.delete<CommandResponse<TuningDto>>(`${this.baseUrl}/api/${ApiPaths.Tunings}/${id}`);
  }
}
