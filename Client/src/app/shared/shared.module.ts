import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AlbumTypePipe } from './pipes/album-type.pipe';
import { InstrumentPipe } from './pipes/instrument.pipe';

@NgModule({
  declarations: [
    AlbumTypePipe,
    InstrumentPipe,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
  ],
  exports: [
    AlbumTypePipe,
    InstrumentPipe,
  ],
  providers: [],
  bootstrap: []
})
export class SharedModule { }
