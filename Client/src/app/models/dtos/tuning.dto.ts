import { Instrument } from "../enums/instrument.enum";
import { TabDto } from "./tab.dto";

export interface TuningDto {
    id: string,
    stringNumber: number,
    name: string,
    strings: string,
    instrument: Instrument,
    tabs: TabDto[],
}
