using System;

using Microsoft.EntityFrameworkCore;

using Tabloid.Domain.Entities;
using Tabloid.Domain.Enums;

namespace Tabloid.Infrastructure.DbContextInitializers;

public class DefaultDbContextInitializer : IDbContextInitializer
{
    public void Seed(ModelBuilder modelBuilder)
    {
        AddTunings(modelBuilder);
        AddGenres(modelBuilder);
    }

    #region Tunings
    private void AddTunings(ModelBuilder modelBuilder)
    {
        var tunings = new[]
        {
            new Tuning { Id = new Guid("14187d55-d884-4d57-a9ad-0964b214dc05"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "Standard", Strings = "E A D G B e" },
            new Tuning { Id = new Guid("182603d3-0d82-4d14-815b-49bad0e4691e"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop D", Strings = "D A D G B E" },
            new Tuning { Id = new Guid("19a4fe53-0739-4324-a3f5-6164b4603b69"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "D# Standard", Strings = "D# G# C# F# A# d#" },
            new Tuning { Id = new Guid("2247d32f-6903-468c-9f3a-fd31baa3f194"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "D Standard", Strings = "D G C F A d" },
            new Tuning { Id = new Guid("251d6db3-8014-4ab8-a12c-27740dc99b41"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "G G C F A d", Strings = "G G C F A d" },
            new Tuning { Id = new Guid("37bffc99-476b-40b9-b1cd-187b302b3852"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "C# Standard", Strings = "C# F# B E G# c#" },
            new Tuning { Id = new Guid("38be4d1b-ceec-4f21-9183-e87327e3dd3a"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop C", Strings = "C G C F A D" },
            new Tuning { Id = new Guid("39dd5a87-ed95-467b-ba8b-2f72013aa028"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop C#", Strings = "C# G# C# F# A# D#" },
            new Tuning { Id = new Guid("3a83823c-b1b1-4b8b-b5d2-48a8aa8dc4ee"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "C Standard", Strings = "C F A# D# G c" },
            new Tuning { Id = new Guid("4dde6b18-553d-42e8-ade2-d084385e4e37"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop B", Strings = "B F# B E G# C#" },
            new Tuning { Id = new Guid("50f230ac-dae4-4d8d-863d-535f24c8d4d8"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "B Standard", Strings = "B E A D F# b" },
            new Tuning { Id = new Guid("59bae8a1-6c22-4f43-b0a7-a8a58e98d501"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop A", Strings = "A E A D F# b" },
            new Tuning { Id = new Guid("5c873434-d0f1-494f-8533-6352fffbdd99"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "Drop A#", Strings = "A# F A# D# G c" },
            new Tuning { Id = new Guid("5e582416-47b7-488d-8958-251d84c77220"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "A Standard", Strings = "A D G C E a" },
            new Tuning { Id = new Guid("65fb8820-670f-4cba-9cfd-8cb93b734428"), Instrument = Instrument.Guitar, StringNumber = 6, Name = "A# Standard", Strings = "A# D# G# C# F a#" },

            new Tuning { Id = new Guid("66eb5696-a633-45d2-a9d4-c52ac8748b0c"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "Standard (7-string)", Strings = "B E A D G B e" },
            new Tuning { Id = new Guid("68133730-6b9a-4729-9139-f87af0b79464"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "A# Standard (7-string)", Strings = "A# G# C# F# A# d#" },
            new Tuning { Id = new Guid("8bc047a7-1004-4449-9f3a-20bc9f11991a"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "Drop A (7-string)", Strings = "A E A D G B e" },
            new Tuning { Id = new Guid("948bf3ce-ddf3-4a10-95e8-109826be9040"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "A Standard (7-string)", Strings = "A D G C F A D" },
            new Tuning { Id = new Guid("97647eaf-8cd0-409f-a67a-d7ce18343ec8"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "Drop G (7-string)", Strings = "G D G C F A d" },
            new Tuning { Id = new Guid("988cfe9e-f917-485c-bb79-7171267434ad"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "G Standard (7-string)", Strings = "G C F A# D# G C" },
            new Tuning { Id = new Guid("99ad2f63-d8b9-4d25-af6b-aea917cf9dc0"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "Open C (7-string)", Strings = "G C G C G C E" },
            new Tuning { Id = new Guid("a78e83f3-ca52-468d-97e2-eea510662e92"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "G C G C F A D (7-string)", Strings = "G C G C F A D" },
            new Tuning { Id = new Guid("a80671d2-d9a5-41f5-9fff-c12103229964"), Instrument = Instrument.Guitar, StringNumber = 7, Name = "Drop E (7-string)", Strings = "E B E A D G B" },

            new Tuning { Id = new Guid("ab10dac0-2d86-4133-8885-8848a714d3bf"), Instrument = Instrument.Guitar, StringNumber = 8, Name = "Standard (8-string)", Strings = "F# B E A D G B e" },
            new Tuning { Id = new Guid("ac81e787-10d3-4239-b508-b80f99465d53"), Instrument = Instrument.Guitar, StringNumber = 8, Name = "F Standard (8-string)", Strings = " F A# G# C# F# A# d#" },
            new Tuning { Id = new Guid("b710fd85-0b82-4d49-a0a0-89d7b07cb63b"), Instrument = Instrument.Guitar, StringNumber = 8, Name = "E Standard (8-string)", Strings = "E A D G C F A D" },
            new Tuning { Id = new Guid("c2f0cc51-bec7-4410-8c35-5dbcf8c105c3"), Instrument = Instrument.Guitar, StringNumber = 8, Name = "D# Standard (8-string)", Strings = "D# G# C# F# B E G# d" },
            new Tuning { Id = new Guid("cb838df9-4526-4a80-80dc-7daf1e60483a"), Instrument = Instrument.Guitar, StringNumber = 8, Name = "A Standard (8-string)", Strings = "A D G C F A D G" },
            new Tuning { Id = new Guid("ce42be43-bc04-4cdd-8909-0eafaef42172"), Instrument = Instrument.Guitar, StringNumber = 8, Name = "Drop E (8-string)", Strings = "E B E A D G B e" },
            new Tuning { Id = new Guid("d0291a4d-dee4-4ae9-8507-ebb0141be85b"), Instrument = Instrument.Guitar, StringNumber = 8, Name = "Drop D# (8-string)", Strings = "D# A# D# G# C# F# A# d#" },
            new Tuning { Id = new Guid("e156fbbd-ca8b-4f45-b239-1cf011df0d93"), Instrument = Instrument.Guitar, StringNumber = 8, Name = "Drop D (8-string)", Strings = "D A D G C F A d" },

            new Tuning { Id = new Guid("e2fb00a8-3cec-48f4-964d-d4760fb672b4"), Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass Standard", Strings = "E A D G" },
            new Tuning { Id = new Guid("eb15e7fb-a632-43cf-9abc-27770ea0b3b3"), Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass Drop D", Strings = "D A D G" },
            new Tuning { Id = new Guid("ebe01503-1d1b-4116-a8c7-3cd1625507fa"), Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass D Standard", Strings = "D G C F" },
            new Tuning { Id = new Guid("ee8fd1a2-b5e4-43a6-abf4-66ccc963989f"), Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass Drop C", Strings = "C G C F" },

            new Tuning { Id = new Guid("f8fd50f6-815a-48db-a4d1-eb07c9f86ce2"), Instrument = Instrument.Bass, StringNumber = 4, Name = "Bass C tuned to thirds", Strings = "C F C G" },
            new Tuning { Id = new Guid("fb3d4d5b-9d2b-4656-b3f1-2d024899e1ad"), Instrument = Instrument.Bass, StringNumber = 5, Name = "5-string Bass Standard", Strings = "B E A D G" },
            new Tuning { Id = new Guid("007820a3-4221-4509-b414-81f2f8fa3705"), Instrument = Instrument.Bass, StringNumber = 6, Name = "6-string Bass Standard", Strings = "B E A D G C" },
        };

        modelBuilder
            .Entity<Tuning>()
            .HasData(tunings);
    }
    #endregion

    #region Genres
    private void AddGenres(ModelBuilder modelBuilder)
    {
        var genres = new[]
        {
            new Genre { Id = new Guid("00ba4053-f280-485a-8c91-6e68a5811670"), Name = "Instrumental" },
            new Genre { Id = new Guid("06f3a378-1466-4dce-be31-d07bce66b3bf"), Name = "Jazz" },
            new Genre { Id = new Guid("126a86a1-def6-4d44-9917-b4e23b532502"), Name = "Swing" },
            new Genre { Id = new Guid("143aa742-966b-4c14-8a3e-45e188e8db88"), Name = "Latino" },
            new Genre { Id = new Guid("1792b587-515c-4a74-a63c-3cf23b643e4a"), Name = "Blues" },
            new Genre { Id = new Guid("1bd4fd5e-8906-4e61-8b47-2894a187b218"), Name = "Pop" },
            new Genre { Id = new Guid("1e295e89-65a8-4d97-b0bb-8a86b8848dbf"), Name = "Rap" },
            new Genre { Id = new Guid("20d40963-af4b-446e-b56f-88fed4f7ccc5"), Name = "RnB" },
            new Genre { Id = new Guid("29d81cde-da70-4163-b950-decd69e25f35"), Name = "Hip-hop" },
            new Genre { Id = new Guid("29ebba88-99a8-4c77-8913-648a4960fbdc"), Name = "Country" },
            new Genre { Id = new Guid("2b365e69-6d14-4158-adca-e61bc4b6ea1d"), Name = "Reggae" },
            new Genre { Id = new Guid("2d27174e-6cea-4aed-aea3-795e67a3b6af"), Name = "New wave" },
            new Genre { Id = new Guid("2e7a36be-ffb0-4966-b283-c61ec7da62ae"), Name = "Soul" },
            new Genre { Id = new Guid("311c94c8-f483-4a6e-8f1b-277d9c6d9d6e"), Name = "Meme" },
            new Genre { Id = new Guid("352e4e24-e6d6-4252-a03d-ef59ad1ec24f"), Name = "Anime" },
            new Genre { Id = new Guid("3575068a-c9cf-48d5-9863-c8a51bded998"), Name = "K-pop" },
            new Genre { Id = new Guid("3610eea6-f7ed-45ba-ac7e-c12428216b66"), Name = "Rock" },
            new Genre { Id = new Guid("36b06ce2-4398-4d86-ac2e-85d6671cd65a"), Name = "Hard Rock" },
            new Genre { Id = new Guid("392e5b99-789f-4a3f-8e62-12b7fa49b50d"), Name = "Alternative Rock" },
            new Genre { Id = new Guid("39d8b25d-c0b8-480b-9fc4-89b8ac6f4d2e"), Name = "Progressive Rock" },
            new Genre { Id = new Guid("3a41bba1-de93-4a60-b73c-e6f4c116c974"), Name = "Surf Rock" },
            new Genre { Id = new Guid("3b48b284-d160-4902-8157-351af90b7dea"), Name = "Indie Rock" },
            new Genre { Id = new Guid("3e15d1dd-4a5e-43ed-903f-5265eef916ab"), Name = "Psychedelic Rock" },
            new Genre { Id = new Guid("4b2ce0e5-7ad9-4d49-bbdd-18df8bcd89ac"), Name = "Math Rock" },
            new Genre { Id = new Guid("4ca16a7b-6d34-4b1a-a712-ba1de65f0490"), Name = "Pop Rock" },
            new Genre { Id = new Guid("4ea6c397-a74a-454b-96cd-5c332b06a05f"), Name = "Blues Rock" },
            new Genre { Id = new Guid("5361222c-0e8a-485b-96e6-84758a1f8cf8"), Name = "Reggae Rock" },
            new Genre { Id = new Guid("5915e7e0-abaa-4448-a38a-11dc5bba281a"), Name = "Jazz Rock" },
            new Genre { Id = new Guid("61079d22-1773-4f62-a094-dae968ec2523"), Name = "Funk Rock" },
            new Genre { Id = new Guid("67762cf4-91c2-4bb2-995c-2279f4959f39"), Name = "Industrial Rock" },
            new Genre { Id = new Guid("688672b4-d039-472d-8f68-0b16b4d21099"), Name = "Punk rock" },
            new Genre { Id = new Guid("69fbc41b-e2a5-4ee1-a5d6-a901b5ecd2c5"), Name = "Heavy Metal" },
            new Genre { Id = new Guid("6ac4cd9e-0eac-4397-931a-87c59aadcf3f"), Name = "Avant-Garde Metal" },
            new Genre { Id = new Guid("6dd672ed-f2d6-4496-ac35-26535fb64933"), Name = "Extreme Metal" },
            new Genre { Id = new Guid("708d1a13-398e-4b7a-951a-344443762a20"), Name = "Black Metal" },
            new Genre { Id = new Guid("7303ac90-d829-4eaa-b875-e84789befb20"), Name = "Doom Metal" },
            new Genre { Id = new Guid("7342426b-440f-48ba-b559-a0ec1dce7918"), Name = "Death Metal" },
            new Genre { Id = new Guid("75ac8f78-af29-4907-897d-569b200f5b70"), Name = "Thrash Metal" },
            new Genre { Id = new Guid("78bd8712-345a-420a-adfe-755ebbaca901"), Name = "Crossover Thrash" },
            new Genre { Id = new Guid("79f91a8e-f9ca-48d7-83e9-501e957079de"), Name = "Punk Metal" },
            new Genre { Id = new Guid("806c90ad-5dfc-4dd8-b0d6-504bed981cb7"), Name = "Speed Metal" },
            new Genre { Id = new Guid("823ff86e-c1b4-4adc-b3be-381a6445e01d"), Name = "Glam Metal" },
            new Genre { Id = new Guid("89c7935d-cbd3-40e1-bddb-5471c3c65d26"), Name = "Groove Metal" },
            new Genre { Id = new Guid("8c299b0d-f492-4493-9971-6274f3df72d8"), Name = "Power Metal" },
            new Genre { Id = new Guid("8ee31aa9-9992-4b73-8a46-fc8260dc1d52"), Name = "Symphonic Metal" },
            new Genre { Id = new Guid("9088cf8e-ba8a-4d04-87e9-f8c6b28072a1"), Name = "Melodic Death Metal" },
            new Genre { Id = new Guid("933f74f0-2dad-4f18-aa3c-4cb7c2b4e31f"), Name = "Technical Death Metal" },
            new Genre { Id = new Guid("94608f06-bbba-483c-a874-5d73a6a86819"), Name = "Math Metal" },
            new Genre { Id = new Guid("94f2dd00-fa92-4d1a-ba9a-a91f5c5e87a2"), Name = "Alternative Metal" },
            new Genre { Id = new Guid("9818250b-8943-4dda-9773-70976f0f5e63"), Name = "Nu Metal" },
            new Genre { Id = new Guid("9eb79154-d693-442d-9f3a-5851d5bd409c"), Name = "Folk Metal" },
            new Genre { Id = new Guid("a2e791b8-f76b-417a-89fa-944e941e71d3"), Name = "Progressive Metal" },
            new Genre { Id = new Guid("a3afcbd3-58a7-41c8-a14a-1b2ab7c2af4a"), Name = "Djent" },
            new Genre { Id = new Guid("a530cf67-2101-4957-807a-11de50385706"), Name = "Gothic Metal" },
            new Genre { Id = new Guid("a7206a81-c107-49b9-83b0-49cd6bd50b77"), Name = "Industrial Metal" },
            new Genre { Id = new Guid("a8c63f3f-bd3e-4b24-bc51-bdda58dfdcff"), Name = "Neue Deutsche Härte" },
            new Genre { Id = new Guid("ac0dcd5b-57e2-4033-bb64-5ea8387af0ee"), Name = "Rap Metal" },
            new Genre { Id = new Guid("bc0eaa4c-4286-4f64-84bf-01a6dd8ec550"), Name = "Sludge Metal" },
            new Genre { Id = new Guid("bdb370ea-2bc7-4ab9-ba3b-50f15d642444"), Name = "Viking Metal" },
            new Genre { Id = new Guid("be9f2922-505b-4548-9dd5-dd83e8511f50"), Name = "Pirate Metal" },
            new Genre { Id = new Guid("c9672803-489c-4041-a847-e0882812f9ba"), Name = "National Socialist Black Metal" },
            new Genre { Id = new Guid("c98ceb06-0e39-4401-af13-f8195588c612"), Name = "Depressive Suicidal Black Metal" },
            new Genre { Id = new Guid("cbfcd2ee-006e-405c-a68d-a324c3fc1fe2"), Name = "Red and Anarchist Black Metal" },
            new Genre { Id = new Guid("cf0ece86-c9d5-4229-b256-d366a8a0a4e1"), Name = "Blackened Heavy Metal" },
            new Genre { Id = new Guid("cfb80e1c-efcd-4c0c-82da-5251e4b4bdba"), Name = "Metalcore" },
            new Genre { Id = new Guid("d021debb-afd8-4020-ad69-87a845200ac3"), Name = "Deathcore" },
            new Genre { Id = new Guid("d1ef7caf-3c8f-442b-baa7-741449cdbb52"), Name = "Mathcore" },
            new Genre { Id = new Guid("d76f547c-cb1a-483c-9c36-299d49ab6eea"), Name = "Electronicore" },
            new Genre { Id = new Guid("ec973518-563a-4963-839d-d52add39c0ac"), Name = "Grindcore" },
            new Genre { Id = new Guid("edbbc352-9d5f-402a-839b-0b0e45626f32"), Name = "Goregrind" },
            new Genre { Id = new Guid("ef9ec3d2-8781-4943-8aee-fafd726dc927"), Name = "Pornogrind" },
            new Genre { Id = new Guid("efa82c71-9fc2-49d2-b1b5-a0afc242c928"), Name = "Electro" },
            new Genre { Id = new Guid("f227bdf6-ae97-476c-adbf-f36fdd9eac11"), Name = "Dubstep" },
            new Genre { Id = new Guid("f30ee2f7-4372-4e72-a59d-790f1274a3e3"), Name = "Chillstep" },
            new Genre { Id = new Guid("f38533e8-cb20-4fb4-b7ff-0b2158d9cc1e"), Name = "Glichhop" },
            new Genre { Id = new Guid("f63b8ea6-617a-4ec7-81fb-ccba1c55211b"), Name = "Ambient" },
            new Genre { Id = new Guid("f6992f76-c8a2-4485-97db-628d793b84df"), Name = "Wave" },
            new Genre { Id = new Guid("f6d9b483-53ac-4ba1-93c1-0cc3cfade0e6"), Name = "Lofi" },
            new Genre { Id = new Guid("f9918a17-66f3-4eaa-8a95-110034717541"), Name = "Drumstep" },
            new Genre { Id = new Guid("fa1c9b62-b6bc-4f07-a825-a852e34769a1"), Name = "Hardcore" },
            new Genre { Id = new Guid("fa6a53ff-0fa2-4518-a3af-6bc4cd332ae8"), Name = "House" },
            new Genre { Id = new Guid("fbc655a7-8125-4ed4-81f9-0c69d8a74685"), Name = "Trap" },
            new Genre { Id = new Guid("fccc9965-3505-457a-b361-a931dbb20d5c"), Name = "Tance" },
        };

        modelBuilder
            .Entity<Genre>()
            .HasData(genres);
    }
    #endregion
}
