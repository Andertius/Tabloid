import { SongDto } from "./song.dto";

export interface GenreDto {
    id: string,
    name: string,

    songs: SongDto[]
}
