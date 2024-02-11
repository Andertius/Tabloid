import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommandResponse } from 'src/app/models/command-response.model';
import { TabDto } from 'src/app/models/dtos/tab.dto';
import { environment } from 'src/environments/environment';
import { ApiPaths } from '../enums/api-paths.enum';

@Injectable({
  providedIn: 'root'
})
export class TabService {

  baseUrl = environment.baseUrl;

  constructor(private readonly http: HttpClient) { }

  public addTab = (tab: TabDto) => {
    return this.http.post<CommandResponse<TabDto>>(`${this.baseUrl}/api/${ApiPaths.Tabs}`, tab);
  }

  public editTab = (tab: TabDto) => {
    return this.http.put<CommandResponse<TabDto>>(`${this.baseUrl}/api/${ApiPaths.Tabs}`, tab);
  }

  public deleteTab = (id: string) => {
    return this.http.delete<CommandResponse<TabDto>>(`${this.baseUrl}/api/${ApiPaths.Tabs}/${id}`);
  }
}
