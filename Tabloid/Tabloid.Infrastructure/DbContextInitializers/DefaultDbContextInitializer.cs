using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Infrastructure.DbContextInitializers
{
    public class DefaultDbContextInitializer : IDbContextInitializer
    {
        private ModelBuilder _modelBuilder;

        public void Seed(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            AddTunings();
            AddGenres();
        }

        #region Tunings
        private void AddTunings()
        {
            var tunings = new[]
            {
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "Standard", Strings = "E A D G B e" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop D", Strings = "D A D G B E" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "D# Standard", Strings = "D# G# C# F# A# d#" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "D Standard", Strings = "D G C F A d" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "G G C F A d", Strings = "G G C F A d" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "C# Standard", Strings = "C# F# B E G# c#" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop C", Strings = "C G C F A D" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop C#", Strings = "C# G# C# F# A# D#" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "C Standard", Strings = "C F A# D# G c" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop B", Strings = "B F# B E G# C#" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "B Standard", Strings = "B E A D F# b" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop A", Strings = "A E A D F# b" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop A#", Strings = "A# F A# D# G c" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "A Standard", Strings = "A D G C E a" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 6, Name = "A# Standard", Strings = "A# D# G# C# F a#" },

                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "Standard (7-string)", Strings = "B E A D G B e" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "A# Standard (7-string)", Strings = "A# G# C# F# A# d#" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "Drop A (7-string)", Strings = "A E A D G B e" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "A Standard (7-string)", Strings = "A D G C F A D" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "Drop G (7-string)", Strings = "G D G C F A d" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "G Standard (7-string)", Strings = "G C F A# D# G C" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "Open C (7-string)", Strings = "G C G C G C E" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "G C G C F A D (7-string)", Strings = "G C G C F A D" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 7, Name = "Drop E (7-string)", Strings = "E B E A D G B" },

                new Tuning { Instrument = Instrument.Guitar, StringNumber = 8, Name = "Standard (8-string)", Strings = "F# B E A D G B e" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 8, Name = "F Standard (8-string)", Strings = " F A# G# C# F# A# d#" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 8, Name = "E Standard (8-string)", Strings = "E A D G C F A D" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 8, Name = "D# Standard (8-string)", Strings = "D# G# C# F# B E G# d" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 8, Name = "A Standard (8-string)", Strings = "A D G C F A D G" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 8, Name = "Drop E (8-string)", Strings = "E B E A D G B e" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 8, Name = "Drop D# (8-string)", Strings = "D# A# D# G# C# F# A# d#" },
                new Tuning { Instrument = Instrument.Guitar, StringNumber = 8, Name = "Drop D (8-string)", Strings = "D A D G C F A d" },

                new Tuning { Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass Standard", Strings = "E A D G" },
                new Tuning { Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass Drop D", Strings = "D A D G" },
                new Tuning { Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass D Standard", Strings = "D G C F" },
                new Tuning { Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass Drop C", Strings = "C G C F" },
                new Tuning { Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass C tuned to thirds", Strings = "C F C G" },

                new Tuning { Instrument = Instrument.Bass, StringNumber = 5, Name = "5-string Bass Standard", Strings = "B E A D G" },
                new Tuning { Instrument = Instrument.Bass, StringNumber = 5, Name = "6-string Bass Standard", Strings = "B E A D G C" },
            };

            _modelBuilder
                .Entity<Tuning>()
                .HasData(tunings.Select(x => new Tuning
                {
                    Id = Guid.NewGuid(),
                    Instrument = x.Instrument,
                    Strings = x.Strings,
                    StringNumber = x.StringNumber,
                    Name = x.Name,
                }));
        }
        #endregion

        #region Genres
        private void AddGenres()
        {
            var genres = new[]
            {
                new Genre { Id = Guid.NewGuid(), Name = "Instrumental" },
                new Genre { Id = Guid.NewGuid(), Name = "Jazz" },
                new Genre { Id = Guid.NewGuid(), Name = "Swing" },
                new Genre { Id = Guid.NewGuid(), Name = "Latino" },
                new Genre { Id = Guid.NewGuid(), Name = "Blues" },
                new Genre { Id = Guid.NewGuid(), Name = "Pop" },
                new Genre { Id = Guid.NewGuid(), Name = "Rap" },
                new Genre { Id = Guid.NewGuid(), Name = "RnB" },
                new Genre { Id = Guid.NewGuid(), Name = "Hip-hop" },
                new Genre { Id = Guid.NewGuid(), Name = "Country" },
                new Genre { Id = Guid.NewGuid(), Name = "Reggae" },
                new Genre { Id = Guid.NewGuid(), Name = "New wave" },
                new Genre { Id = Guid.NewGuid(), Name = "Soul" },
                new Genre { Id = Guid.NewGuid(), Name = "Meme" },
                new Genre { Id = Guid.NewGuid(), Name = "Anime" },
                new Genre { Id = Guid.NewGuid(), Name = "K-pop" },

                new Genre { Id = Guid.NewGuid(), Name = "Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Hard Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Alternative Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Progressive Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Surf Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Indie Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Psychedelic Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Math Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Pop Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Blues Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Reggae Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Jazz Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Funk Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Industrial Rock" },
                new Genre { Id = Guid.NewGuid(), Name = "Punk rock" },

                new Genre { Id = Guid.NewGuid(), Name = "Heavy Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Avant-Garde Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Extreme Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Black Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Doom Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Death Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Thrash Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Crossover Thrash" },
                new Genre { Id = Guid.NewGuid(), Name = "Punk Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Speed Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Glam Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Groove Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Power Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Symphonic Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Melodic Death Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Technical Death Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Math Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Alternative Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Nu Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Folk Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Progressive Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Djent" },
                new Genre { Id = Guid.NewGuid(), Name = "Gothic Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Industrial Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Neue Deutsche Härte" },
                new Genre { Id = Guid.NewGuid(), Name = "Rap Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Sludge Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Viking Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Pirate Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "National Socialist Black Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Depressive Suicidal Black Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Red and Anarchist Black Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Blackened Heavy Metal" },
                new Genre { Id = Guid.NewGuid(), Name = "Metalcore" },
                new Genre { Id = Guid.NewGuid(), Name = "Deathcore" },
                new Genre { Id = Guid.NewGuid(), Name = "Mathcore" },
                new Genre { Id = Guid.NewGuid(), Name = "Electronicore" },
                new Genre { Id = Guid.NewGuid(), Name = "Grindcore" },
                new Genre { Id = Guid.NewGuid(), Name = "Goregrind" },
                new Genre { Id = Guid.NewGuid(), Name = "Pornogrind" },

                new Genre { Id = Guid.NewGuid(), Name = "Electro" },
                new Genre { Id = Guid.NewGuid(), Name = "Dubstep" },
                new Genre { Id = Guid.NewGuid(), Name = "Chillstep" },
                new Genre { Id = Guid.NewGuid(), Name = "Glichhop" },
                new Genre { Id = Guid.NewGuid(), Name = "Ambient" },
                new Genre { Id = Guid.NewGuid(), Name = "Wave" },
                new Genre { Id = Guid.NewGuid(), Name = "Lofi" },
                new Genre { Id = Guid.NewGuid(), Name = "Drumstep" },
                new Genre { Id = Guid.NewGuid(), Name = "Hardcore" },
                new Genre { Id = Guid.NewGuid(), Name = "House" },
                new Genre { Id = Guid.NewGuid(), Name = "Trap" },
                new Genre { Id = Guid.NewGuid(), Name = "Tance" },
            };

            _modelBuilder
                .Entity<Genre>()
                .HasData(genres);
        }
        #endregion
    }
}
