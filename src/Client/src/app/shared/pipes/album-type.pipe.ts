import { Pipe, PipeTransform } from '@angular/core';
import { AlbumType } from 'src/app/models/enums/album-type.enum';

@Pipe({
  name: 'albumType'
})
export class AlbumTypePipe implements PipeTransform {

  transform(value: AlbumType): string {
    return AlbumType[value];
  }

}
