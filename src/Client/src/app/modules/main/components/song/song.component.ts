import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { SongDto } from 'src/app/models/dtos/song.dto';
import { TabDto } from 'src/app/models/dtos/tab.dto';
import { AddTabDialogComponent } from 'src/app/modules/dialog/components/tabs/add-tab-dialog/add-tab-dialog.component';
import { ImageService } from 'src/app/shared/services/image.service';
import { SongService } from 'src/app/shared/services/song.service';
import { StringService } from 'src/app/shared/services/string.service';
import { TabService } from 'src/app/shared/services/tab.service';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.scss']
})
export class SongComponent implements OnInit {

  song!: SongDto;

  constructor(
    private readonly dialog: MatDialog,
    private readonly tabService: TabService,
    private readonly stringService: StringService,
    private readonly songService: SongService,
    private readonly imageService: ImageService,
    private readonly activatedRoute: ActivatedRoute,
    private readonly router: Router) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get("id");

    if (id === null) {
      this.router.navigate(['home']);
      return;
    }

    this.songService.fetchSong(id)
      .subscribe(response => this.song = response);
  }

  setFavourite() {
    this.songService.setFavourite(this.song.id, !this.song.isFavourite)
      .subscribe(response => {
        this.song = response.object;
      });
  }

  setMastered() {
    this.songService.setMastered(this.song.id, !this.song.fullyMastered)
      .subscribe(response => {
        this.song = response.object;
      });
  }

  getImageSource() {
    return this.imageService.getAlbumImageSource(this.song.album);
  }

  addTab() {
    const dialogRef = this.dialog.open(AddTabDialogComponent, {
      width: '400px',
    });

    dialogRef
      .afterClosed()
      .subscribe((result: FormGroup) => {
        if (result !== undefined) {
          const tab: TabDto = {
            id: "00000000-0000-0000-0000-000000000000",
            name: result.controls["name"].value,
            difficulty: result.controls["difficulty"].value,
            link: result.controls["link"].value,
            tuning: result.controls["tuning"].value,
            song: this.song,
          };

          this.tabService.addTab(tab)
            .subscribe(response => {
              this.song.tabs.push(response.object);
              this.song.tabs.sort(this.stringService.compareNamesRemoveArticles);
            })
        }
      })
  }

  rerenderTabsAfterDelete(event: any) {
    this.song.tabs = this.song.tabs.filter(x => x.id !== event.id)
    
    this.song.tabs = this.song.tabs.sort(this.stringService.compareNamesRemoveArticles);
  }

  rerenderTabsAfterEdit(event: any) {
    const allGenresIndex = this.song.tabs.indexOf(this.song.tabs.filter(x => x.id === event.tab.id)[0]);

    this.song.tabs[allGenresIndex] = event.tab;
    
    this.song.tabs = this.song.tabs.sort(this.stringService.compareNamesRemoveArticles);
  }

}
