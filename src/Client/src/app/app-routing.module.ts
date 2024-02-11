import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlbumComponent } from './modules/main/components/album/album.component';
import { AlbumsComponent } from './modules/main/components/albums/albums.component';
import { ArtistComponent } from './modules/main/components/artist/artist.component';
import { ArtistsComponent } from './modules/main/components/artists/artists.component';
import { GenresComponent } from './modules/main/components/genres/genres.component';
import { HomeComponent } from './modules/main/components/home/home.component';
import { SongComponent } from './modules/main/components/song/song.component';
import { SongsComponent } from './modules/main/components/songs/songs.component';
import { TuningsComponent } from './modules/main/components/tunings/tunings.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'artists', component: ArtistsComponent },
  { path: 'albums', component: AlbumsComponent },
  { path: 'genres', component: GenresComponent },
  { path: 'songs', component: SongsComponent },
  { path: 'tunings', component: TuningsComponent },
  { path: 'artist/:id', component: ArtistComponent },
  { path: 'album/:id', component: AlbumComponent },
  { path: 'song/:id', component: SongComponent },
  { path: '', pathMatch: 'full', redirectTo: 'home', },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
