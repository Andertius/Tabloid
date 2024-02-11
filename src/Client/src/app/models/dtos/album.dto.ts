import { AlbumType } from "../enums/album-type.enum";
import { ArtistDto } from "./artist.dto";
import { SongDto } from "./song.dto";

export interface AlbumDto {
    id: string,
    name: string,
    cover: string,
    year: number,
    albumType: AlbumType,
    artist: ArtistDto,
    songs: SongDto[],
}
