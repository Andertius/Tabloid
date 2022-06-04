import { ArtistDto } from "./artist.dto";
import { SongDto } from "./song.dto";

export interface AlbumDto {
    id: string,
    name: string,
    cover: string,
    year: number,
    artist: ArtistDto,
    songs: SongDto[],
}
