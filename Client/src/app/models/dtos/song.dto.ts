import { AlbumDto } from "./album.dto";
import { ArtistDto } from "./artist.dto";
import { GenreDto } from "./genre.dto";
import { TabDto } from "./tab.dto";

export interface SongDto {
    id: string,
    name: string,
    songNumberInAlbum: number,
    fullyMastered: number,
    isFavourite: boolean,
    album: AlbumDto,
    tabs: TabDto[],
    genres: GenreDto[],
    artists: ArtistDto[]
}
