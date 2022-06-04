import { AlbumDto } from "./album.dto";
import { SongDto } from "./song.dto";

export interface ArtistDto {
    id: string,
    name: string,
    image: string,

    songs: SongDto[],
    albums: AlbumDto[],
}
