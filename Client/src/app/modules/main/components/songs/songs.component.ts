import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { TabDto } from 'src/app/models/dtos/tab.dto';
import { ImageService } from 'src/app/shared/services/image.service';
import { SongService } from 'src/app/shared/services/song.service';
import { StringService } from 'src/app/shared/services/string.service';
import { TabService } from 'src/app/shared/services/tab.service';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.scss']
})
export class SongsComponent implements OnInit {

  allSongs: SongDto[] = [];
  filteredSongs: SongDto[] = [];

  formControl = new FormControl();

  constructor(
    private readonly dialog: MatDialog,
    private readonly tabService: TabService,
    private readonly stringService: StringService,
    private readonly songService: SongService,
    private readonly imageService: ImageService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router) { }

  ngOnInit(): void {
    this.songService.fetchSongs()
      .subscribe(response => {
        this.filteredSongs = response;
        this.filteredSongs.sort(this.stringService.compareNamesRemoveArticles);
        
        this.allSongs = this.filteredSongs.filter(x => x);
      })
  }

  searchChanged() {
    this.filteredSongs = this.allSongs.filter(x =>
      x.name.toLowerCase().includes(this.formControl.value.toLowerCase()) ||
      x.album.name.toLowerCase().includes(this.formControl.value.toLowerCase()) ||
      x.artists.some(y => y.name.toLowerCase().includes(this.formControl.value.toLowerCase())))
  }

}
