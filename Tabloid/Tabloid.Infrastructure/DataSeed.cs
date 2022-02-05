using System.Reflection;

using Tabloid.Domain.Entities;

namespace Tabloid.Infrastructure
{
    public class DataSeed
    {
        private readonly TabDbContext _context;

        private readonly List<string> DbSets = new()
        {
            nameof(TabDbContext.Tunings),
            nameof(TabDbContext.Genres),
            nameof(TabDbContext.Artists),
            nameof(TabDbContext.Albums),
            nameof(TabDbContext.Songs),
        };

        private readonly List<Artist> _artists = new();
        private readonly List<Album> _albums = new();
        private readonly List<Genre> _genres = new();

        public DataSeed(TabDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            // Go through every DbSet in _context and fill them with data if they are empty.
            foreach (var dbSet in DbSets)
            {
                if (!CheckForElements(typeof(TabDbContext)
                        .GetProperty(dbSet)
                        .GetMethod
                        .Invoke(_context, Array.Empty<object>())))
                {
                    typeof(DataSeed)
                        .GetMethod($"Add{dbSet}", BindingFlags.Instance | BindingFlags.NonPublic)
                        .Invoke(this, null);
                }
            }

            _context.SaveChanges();
        }

#pragma warning disable IDE0051 // Remove unused private members
        #region Tunings
        private void AddTunings()
        {
            _context.Tunings.AddRange(new[]
                {
                    new GuitarTuning { StringNumber = 6, Name = "Standard", Tuning = "E A D G B e" },
                    new GuitarTuning { StringNumber = 6, Name = "Drop D", Tuning = "D A D G B E" },
                    new GuitarTuning { StringNumber = 6, Name = "D# Standard", Tuning = "D# G# C# F# A# d#" },
                    new GuitarTuning { StringNumber = 6, Name = "D Standard", Tuning = "D G C F A d" },
                    new GuitarTuning { StringNumber = 6, Name = "G G C F A d", Tuning = "G G C F A d" },
                    new GuitarTuning { StringNumber = 6, Name = "C# Standard", Tuning = "C# F# B E G# c#" },
                    new GuitarTuning { StringNumber = 6, Name = "Drop C", Tuning = "C G C F A D" },
                    new GuitarTuning { StringNumber = 6, Name = "Drop C#", Tuning = "C# G# C# F# A# D#" },
                    new GuitarTuning { StringNumber = 6, Name = "C Standard", Tuning = "C F A# D# G c" },
                    new GuitarTuning { StringNumber = 6, Name = "Drop B", Tuning = "B F# B E G# C#" },
                    new GuitarTuning { StringNumber = 6, Name = "B Standard", Tuning = "B E A D F# b" },
                    new GuitarTuning { StringNumber = 6, Name = "Drop A", Tuning = "A E A D F# b" },
                    new GuitarTuning { StringNumber = 6, Name = "Drop A#", Tuning = "A# F A# D# G c" },
                    new GuitarTuning { StringNumber = 6, Name = "A Standard", Tuning = "A D G C E a" },
                    new GuitarTuning { StringNumber = 6, Name = "A# Standard", Tuning = "A# D# G# C# F a#" },

                    new GuitarTuning { StringNumber = 7, Name = "Standard (7-string)", Tuning = "B E A D G B e" },
                    new GuitarTuning { StringNumber = 7, Name = "A# Standard (7-string)", Tuning = "A# G# C# F# A# d#" },
                    new GuitarTuning { StringNumber = 7, Name = "Drop A (7-string)", Tuning = "A E A D G B e" },
                    new GuitarTuning { StringNumber = 7, Name = "A Standard (7-string)", Tuning = "A D G C F A D" },
                    new GuitarTuning { StringNumber = 7, Name = "Drop G (7-string)", Tuning = "G D G C F A d" },
                    new GuitarTuning { StringNumber = 7, Name = "G Standard (7-string)", Tuning = "G C F A# D# G C" },
                    new GuitarTuning { StringNumber = 7, Name = "Open C (7-string)", Tuning = "G C G C G C E" },
                    new GuitarTuning { StringNumber = 7, Name = "G C G C F A D (7-string)", Tuning = "G C G C F A D" },
                    new GuitarTuning { StringNumber = 7, Name = "Drop E (7-string)", Tuning = "E B E A D G B" },

                    new GuitarTuning { StringNumber = 8, Name = "Standard (8-string)", Tuning = "F# B E A D G B e" },
                    new GuitarTuning { StringNumber = 8, Name = "F Standard (8-string)", Tuning = " F A# G# C# F# A# d#" },
                    new GuitarTuning { StringNumber = 8, Name = "E Standard (8-string)", Tuning = "E A D G C F A D" },
                    new GuitarTuning { StringNumber = 8, Name = "D# Standard (8-string)", Tuning = "D# G# C# F# B E G# d" },
                    new GuitarTuning { StringNumber = 8, Name = "A Standard (8-string)", Tuning = "A D G C F A D G" },
                    new GuitarTuning { StringNumber = 8, Name = "Drop E (8-string)", Tuning = "E B E A D G B e" },
                    new GuitarTuning { StringNumber = 8, Name = "Drop D# (8-string)", Tuning = "D# A# D# G# C# F# A# d#" },
                    new GuitarTuning { StringNumber = 8, Name = "Drop D (8-string)", Tuning = "D A D G C F A d" },
                });
        }
        #endregion

        #region Genres
        private void AddGenres()
        {
            _genres.AddRange(new[]
            {
                new Genre { Name = "Instrumental" },
                new Genre { Name = "Jazz" },
                new Genre { Name = "Swing" },
                new Genre { Name = "Latino" },
                new Genre { Name = "Blues" },
                new Genre { Name = "Pop" },
                new Genre { Name = "Rap" },
                new Genre { Name = "RnB" },
                new Genre { Name = "Hip-hop" },
                new Genre { Name = "Country" },
                new Genre { Name = "Reggae" },
                new Genre { Name = "New wave" },
                new Genre { Name = "Soul" },
                new Genre { Name = "Meme" },
                new Genre { Name = "Anime" },
                new Genre { Name = "K-pop" },

                new Genre { Name = "Rock" },
                new Genre { Name = "Hard Rock" },
                new Genre { Name = "Alternative Rock" },
                new Genre { Name = "Progressive Rock" },
                new Genre { Name = "Surf Rock" },
                new Genre { Name = "Indie Rock" },
                new Genre { Name = "Psychedelic Rock" },
                new Genre { Name = "Math Rock" },
                new Genre { Name = "Pop Rock" },
                new Genre { Name = "Blues Rock" },
                new Genre { Name = "Reggae Rock" },
                new Genre { Name = "Jazz Rock" },
                new Genre { Name = "Funk Rock" },
                new Genre { Name = "Industrial Rock" },
                new Genre { Name = "Punk rock" },

                new Genre { Name = "Heavy Metal" },
                new Genre { Name = "Avant-Garde Metal" },
                new Genre { Name = "Extreme Metal" },
                new Genre { Name = "Black Metal" },
                new Genre { Name = "Doom Metal" },
                new Genre { Name = "Death Metal" },
                new Genre { Name = "Thrash Metal" },
                new Genre { Name = "Crossover Thrash" },
                new Genre { Name = "Punk Metal" },
                new Genre { Name = "Speed Metal" },
                new Genre { Name = "Glam Metal" },
                new Genre { Name = "Groove Metal" },
                new Genre { Name = "Power Metal" },
                new Genre { Name = "Symphonic Metal" },
                new Genre { Name = "Melodic Death Metal" },
                new Genre { Name = "Technical Death Metal" },
                new Genre { Name = "Math Metal" },
                new Genre { Name = "Alternative Metal" },
                new Genre { Name = "Nu Metal" },
                new Genre { Name = "Folk Metal" },
                new Genre { Name = "Progressive Metal" },
                new Genre { Name = "Djent" },
                new Genre { Name = "Gothic Metal" },
                new Genre { Name = "Industrial Metal" },
                new Genre { Name = "Neue Deutsche Härte" },
                new Genre { Name = "Rap Metal" },
                new Genre { Name = "Sludge Metal" },
                new Genre { Name = "Viking Metal" },
                new Genre { Name = "Pirate Metal" },
                new Genre { Name = "National Socialist Black Metal" },
                new Genre { Name = "Depressive Suicidal Black Metal" },
                new Genre { Name = "Red and Anarchist Black Metal" },
                new Genre { Name = "Blackened Heavy Metal" },
                new Genre { Name = "Metalcore" },
                new Genre { Name = "Deathcore" },
                new Genre { Name = "Mathcore" },
                new Genre { Name = "Electronicore" },
                new Genre { Name = "Grindcore" },
                new Genre { Name = "Goregrind" },
                new Genre { Name = "Pornogrind" },

                new Genre { Name = "Electro" },
                new Genre { Name = "Dubstep" },
                new Genre { Name = "Chillstep" },
                new Genre { Name = "Glichhop" },
                new Genre { Name = "Ambient" },
                new Genre { Name = "Wave" },
                new Genre { Name = "Lofi" },
                new Genre { Name = "Drumstep" },
                new Genre { Name = "Hardcore" },
                new Genre { Name = "House" },
                new Genre { Name = "Trap" },
                new Genre { Name = "Tance" },
            });

            _context.AddRange(_genres);
        }
        #endregion

        #region Artists
        private void AddArtists()
        {
            _artists.AddRange(new[]
            {
                new Artist { Name = "Metallica",  },
                new Artist { Name = "Kansas" },
                new Artist { Name = "System Of A Down" },
            });

            _context.Artists.AddRange(_artists);
        }
        #endregion

        #region Albums
        private void AddAlbums()
        {
            _albums.AddRange(new[]
            {
                new Album
                {
                    Name = "Kill 'em All",
                    Year = 1983,
                    Artist = _artists.FirstOrDefault(x => x.Name == "Metallica"),
                },
                new Album
                {
                    Name = "Leftoverture",
                    Year = 1976,
                    Artist = _artists.FirstOrDefault(x => x.Name == "Kansas"),
                },
                new Album
                {
                    Name = "System Of A Down",
                    Year = 1998,
                    Artist = _artists.FirstOrDefault(x => x.Name == "System Of A Down"),
                },
            });

            _context.Albums.AddRange(_albums);
        }
        #endregion

        #region Songs
        private void AddSongs()
        {
            _context.Songs.AddRange(new[]
            {
                new Song
                {
                    SongName = "Seek & Destroy",
                    SongNumberInAlbum = 9,
                    Artists = new[] { _artists.FirstOrDefault(x => x.Name == "Metallica") },
                    Genres = new[] { _genres.FirstOrDefault(x => x.Name == "Thrash Metal") },
                    Album = _albums.FirstOrDefault(x => x.Name == "Kill 'em All"),
                },
                new Song
                {
                    SongName = "Carry on Wayward Son",
                    SongNumberInAlbum = 9,
                    Artists = new[] { _artists.FirstOrDefault(x => x.Name == "Kansas") },
                    Genres = new[] { _genres.FirstOrDefault(x => x.Name == "Progressive Rock") },
                    Album = _albums.FirstOrDefault(x => x.Name == "Leftoverture"),
                },
                new Song
                {
                    SongName = "Sugar",
                    SongNumberInAlbum = 9,
                    Artists = new[] { _artists.FirstOrDefault(x => x.Name == "System Of A Down") },
                    Genres = new[] { _genres.FirstOrDefault(x => x.Name == "Alternative Metal") },
                    Album = _albums.FirstOrDefault(x => x.Name == "System Of A Down"),
                },
            });
        }
        #endregion
#pragma warning restore IDE0051 // Remove unused private members

        private static bool CheckForElements(object obj)
        {
            if (obj is IEnumerable<IEntity<Guid>> en)
            {
                return en.Any();
            }

            throw new ArgumentException("Argument has to implement IEnumerable<T>.");
        }
    }
}
