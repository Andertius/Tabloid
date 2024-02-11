import { Pipe, PipeTransform } from '@angular/core';
import { Instrument } from 'src/app/models/enums/instrument.enum';

@Pipe({
  name: 'instrument'
})
export class InstrumentPipe implements PipeTransform {

  transform(value: Instrument): string {
    return Instrument[value];
  }

}
