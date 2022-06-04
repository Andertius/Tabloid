import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArtistCardComponent } from './modules/cards/artist-card/artist-card.component';
import { ArtistComponent } from './modules/main/components/artist/artist.component';
import { HomeComponent } from './modules/main/components/home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'artist-card', component: ArtistCardComponent },
  { path: 'artist/:id', component: ArtistComponent },
  { path: '', pathMatch: 'full', redirectTo: 'home',  },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
