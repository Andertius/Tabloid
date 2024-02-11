import { SongDto } from "./song.dto";
import { TuningDto } from "./tuning.dto";

export interface TabDto {
    id: string,
    name: string,
    link: string,
    difficulty: number,
    tuning: TuningDto,
    song: SongDto,
}
