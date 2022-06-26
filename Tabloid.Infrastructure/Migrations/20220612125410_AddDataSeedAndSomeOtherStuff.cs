using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabloid.Infrastructure.Migrations
{
    public partial class AddDataSeedAndSomeOtherStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Songs_SongId",
                table: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Tunings_Name",
                table: "Tunings");

            migrationBuilder.DropIndex(
                name: "IX_Tunings_Strings",
                table: "Tunings");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs");

            migrationBuilder.AddColumn<int>(
                name: "AlbumType",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00ba4053-f280-485a-8c91-6e68a5811670"), "Instrumental" },
                    { new Guid("06f3a378-1466-4dce-be31-d07bce66b3bf"), "Jazz" },
                    { new Guid("126a86a1-def6-4d44-9917-b4e23b532502"), "Swing" },
                    { new Guid("143aa742-966b-4c14-8a3e-45e188e8db88"), "Latino" },
                    { new Guid("1792b587-515c-4a74-a63c-3cf23b643e4a"), "Blues" },
                    { new Guid("1bd4fd5e-8906-4e61-8b47-2894a187b218"), "Pop" },
                    { new Guid("1e295e89-65a8-4d97-b0bb-8a86b8848dbf"), "Rap" },
                    { new Guid("20d40963-af4b-446e-b56f-88fed4f7ccc5"), "RnB" },
                    { new Guid("29d81cde-da70-4163-b950-decd69e25f35"), "Hip-hop" },
                    { new Guid("29ebba88-99a8-4c77-8913-648a4960fbdc"), "Country" },
                    { new Guid("2b365e69-6d14-4158-adca-e61bc4b6ea1d"), "Reggae" },
                    { new Guid("2d27174e-6cea-4aed-aea3-795e67a3b6af"), "New wave" },
                    { new Guid("2e7a36be-ffb0-4966-b283-c61ec7da62ae"), "Soul" },
                    { new Guid("311c94c8-f483-4a6e-8f1b-277d9c6d9d6e"), "Meme" },
                    { new Guid("352e4e24-e6d6-4252-a03d-ef59ad1ec24f"), "Anime" },
                    { new Guid("3575068a-c9cf-48d5-9863-c8a51bded998"), "K-pop" },
                    { new Guid("3610eea6-f7ed-45ba-ac7e-c12428216b66"), "Rock" },
                    { new Guid("36b06ce2-4398-4d86-ac2e-85d6671cd65a"), "Hard Rock" },
                    { new Guid("392e5b99-789f-4a3f-8e62-12b7fa49b50d"), "Alternative Rock" },
                    { new Guid("39d8b25d-c0b8-480b-9fc4-89b8ac6f4d2e"), "Progressive Rock" },
                    { new Guid("3a41bba1-de93-4a60-b73c-e6f4c116c974"), "Surf Rock" },
                    { new Guid("3b48b284-d160-4902-8157-351af90b7dea"), "Indie Rock" },
                    { new Guid("3e15d1dd-4a5e-43ed-903f-5265eef916ab"), "Psychedelic Rock" },
                    { new Guid("4b2ce0e5-7ad9-4d49-bbdd-18df8bcd89ac"), "Math Rock" },
                    { new Guid("4ca16a7b-6d34-4b1a-a712-ba1de65f0490"), "Pop Rock" },
                    { new Guid("4ea6c397-a74a-454b-96cd-5c332b06a05f"), "Blues Rock" },
                    { new Guid("5361222c-0e8a-485b-96e6-84758a1f8cf8"), "Reggae Rock" },
                    { new Guid("5915e7e0-abaa-4448-a38a-11dc5bba281a"), "Jazz Rock" },
                    { new Guid("61079d22-1773-4f62-a094-dae968ec2523"), "Funk Rock" },
                    { new Guid("67762cf4-91c2-4bb2-995c-2279f4959f39"), "Industrial Rock" },
                    { new Guid("688672b4-d039-472d-8f68-0b16b4d21099"), "Punk rock" },
                    { new Guid("69fbc41b-e2a5-4ee1-a5d6-a901b5ecd2c5"), "Heavy Metal" },
                    { new Guid("6ac4cd9e-0eac-4397-931a-87c59aadcf3f"), "Avant-Garde Metal" },
                    { new Guid("6dd672ed-f2d6-4496-ac35-26535fb64933"), "Extreme Metal" },
                    { new Guid("708d1a13-398e-4b7a-951a-344443762a20"), "Black Metal" },
                    { new Guid("7303ac90-d829-4eaa-b875-e84789befb20"), "Doom Metal" },
                    { new Guid("7342426b-440f-48ba-b559-a0ec1dce7918"), "Death Metal" },
                    { new Guid("75ac8f78-af29-4907-897d-569b200f5b70"), "Thrash Metal" },
                    { new Guid("78bd8712-345a-420a-adfe-755ebbaca901"), "Crossover Thrash" },
                    { new Guid("79f91a8e-f9ca-48d7-83e9-501e957079de"), "Punk Metal" },
                    { new Guid("806c90ad-5dfc-4dd8-b0d6-504bed981cb7"), "Speed Metal" },
                    { new Guid("823ff86e-c1b4-4adc-b3be-381a6445e01d"), "Glam Metal" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("89c7935d-cbd3-40e1-bddb-5471c3c65d26"), "Groove Metal" },
                    { new Guid("8c299b0d-f492-4493-9971-6274f3df72d8"), "Power Metal" },
                    { new Guid("8ee31aa9-9992-4b73-8a46-fc8260dc1d52"), "Symphonic Metal" },
                    { new Guid("9088cf8e-ba8a-4d04-87e9-f8c6b28072a1"), "Melodic Death Metal" },
                    { new Guid("933f74f0-2dad-4f18-aa3c-4cb7c2b4e31f"), "Technical Death Metal" },
                    { new Guid("94608f06-bbba-483c-a874-5d73a6a86819"), "Math Metal" },
                    { new Guid("94f2dd00-fa92-4d1a-ba9a-a91f5c5e87a2"), "Alternative Metal" },
                    { new Guid("9818250b-8943-4dda-9773-70976f0f5e63"), "Nu Metal" },
                    { new Guid("9eb79154-d693-442d-9f3a-5851d5bd409c"), "Folk Metal" },
                    { new Guid("a2e791b8-f76b-417a-89fa-944e941e71d3"), "Progressive Metal" },
                    { new Guid("a3afcbd3-58a7-41c8-a14a-1b2ab7c2af4a"), "Djent" },
                    { new Guid("a530cf67-2101-4957-807a-11de50385706"), "Gothic Metal" },
                    { new Guid("a7206a81-c107-49b9-83b0-49cd6bd50b77"), "Industrial Metal" },
                    { new Guid("a8c63f3f-bd3e-4b24-bc51-bdda58dfdcff"), "Neue Deutsche Härte" },
                    { new Guid("ac0dcd5b-57e2-4033-bb64-5ea8387af0ee"), "Rap Metal" },
                    { new Guid("bc0eaa4c-4286-4f64-84bf-01a6dd8ec550"), "Sludge Metal" },
                    { new Guid("bdb370ea-2bc7-4ab9-ba3b-50f15d642444"), "Viking Metal" },
                    { new Guid("be9f2922-505b-4548-9dd5-dd83e8511f50"), "Pirate Metal" },
                    { new Guid("c9672803-489c-4041-a847-e0882812f9ba"), "National Socialist Black Metal" },
                    { new Guid("c98ceb06-0e39-4401-af13-f8195588c612"), "Depressive Suicidal Black Metal" },
                    { new Guid("cbfcd2ee-006e-405c-a68d-a324c3fc1fe2"), "Red and Anarchist Black Metal" },
                    { new Guid("cf0ece86-c9d5-4229-b256-d366a8a0a4e1"), "Blackened Heavy Metal" },
                    { new Guid("cfb80e1c-efcd-4c0c-82da-5251e4b4bdba"), "Metalcore" },
                    { new Guid("d021debb-afd8-4020-ad69-87a845200ac3"), "Deathcore" },
                    { new Guid("d1ef7caf-3c8f-442b-baa7-741449cdbb52"), "Mathcore" },
                    { new Guid("d76f547c-cb1a-483c-9c36-299d49ab6eea"), "Electronicore" },
                    { new Guid("ec973518-563a-4963-839d-d52add39c0ac"), "Grindcore" },
                    { new Guid("edbbc352-9d5f-402a-839b-0b0e45626f32"), "Goregrind" },
                    { new Guid("ef9ec3d2-8781-4943-8aee-fafd726dc927"), "Pornogrind" },
                    { new Guid("efa82c71-9fc2-49d2-b1b5-a0afc242c928"), "Electro" },
                    { new Guid("f227bdf6-ae97-476c-adbf-f36fdd9eac11"), "Dubstep" },
                    { new Guid("f30ee2f7-4372-4e72-a59d-790f1274a3e3"), "Chillstep" },
                    { new Guid("f38533e8-cb20-4fb4-b7ff-0b2158d9cc1e"), "Glichhop" },
                    { new Guid("f63b8ea6-617a-4ec7-81fb-ccba1c55211b"), "Ambient" },
                    { new Guid("f6992f76-c8a2-4485-97db-628d793b84df"), "Wave" },
                    { new Guid("f6d9b483-53ac-4ba1-93c1-0cc3cfade0e6"), "Lofi" },
                    { new Guid("f9918a17-66f3-4eaa-8a95-110034717541"), "Drumstep" },
                    { new Guid("fa1c9b62-b6bc-4f07-a825-a852e34769a1"), "Hardcore" },
                    { new Guid("fa6a53ff-0fa2-4518-a3af-6bc4cd332ae8"), "House" },
                    { new Guid("fbc655a7-8125-4ed4-81f9-0c69d8a74685"), "Trap" },
                    { new Guid("fccc9965-3505-457a-b361-a931dbb20d5c"), "Tance" }
                });

            migrationBuilder.InsertData(
                table: "Tunings",
                columns: new[] { "Id", "Instrument", "Name", "StringNumber", "Strings" },
                values: new object[] { new Guid("007820a3-4221-4509-b414-81f2f8fa3705"), 1, "6-string Bass Standard", 6, "B E A D G C" });

            migrationBuilder.InsertData(
                table: "Tunings",
                columns: new[] { "Id", "Instrument", "Name", "StringNumber", "Strings" },
                values: new object[,]
                {
                    { new Guid("14187d55-d884-4d57-a9ad-0964b214dc05"), 0, "Standard", 6, "E A D G B e" },
                    { new Guid("182603d3-0d82-4d14-815b-49bad0e4691e"), 0, "Drop D", 6, "D A D G B E" },
                    { new Guid("19a4fe53-0739-4324-a3f5-6164b4603b69"), 0, "D# Standard", 6, "D# G# C# F# A# d#" },
                    { new Guid("2247d32f-6903-468c-9f3a-fd31baa3f194"), 0, "D Standard", 6, "D G C F A d" },
                    { new Guid("251d6db3-8014-4ab8-a12c-27740dc99b41"), 0, "G G C F A d", 6, "G G C F A d" },
                    { new Guid("37bffc99-476b-40b9-b1cd-187b302b3852"), 0, "C# Standard", 6, "C# F# B E G# c#" },
                    { new Guid("38be4d1b-ceec-4f21-9183-e87327e3dd3a"), 0, "Drop C", 6, "C G C F A D" },
                    { new Guid("39dd5a87-ed95-467b-ba8b-2f72013aa028"), 0, "Drop C#", 6, "C# G# C# F# A# D#" },
                    { new Guid("3a83823c-b1b1-4b8b-b5d2-48a8aa8dc4ee"), 0, "C Standard", 6, "C F A# D# G c" },
                    { new Guid("4dde6b18-553d-42e8-ade2-d084385e4e37"), 0, "Drop B", 6, "B F# B E G# C#" },
                    { new Guid("50f230ac-dae4-4d8d-863d-535f24c8d4d8"), 0, "B Standard", 6, "B E A D F# b" },
                    { new Guid("59bae8a1-6c22-4f43-b0a7-a8a58e98d501"), 0, "Drop A", 6, "A E A D F# b" },
                    { new Guid("5c873434-d0f1-494f-8533-6352fffbdd99"), 0, "Drop A#", 6, "A# F A# D# G c" },
                    { new Guid("5e582416-47b7-488d-8958-251d84c77220"), 0, "A Standard", 6, "A D G C E a" },
                    { new Guid("65fb8820-670f-4cba-9cfd-8cb93b734428"), 0, "A# Standard", 6, "A# D# G# C# F a#" },
                    { new Guid("66eb5696-a633-45d2-a9d4-c52ac8748b0c"), 0, "Standard (7-string)", 7, "B E A D G B e" },
                    { new Guid("68133730-6b9a-4729-9139-f87af0b79464"), 0, "A# Standard (7-string)", 7, "A# G# C# F# A# d#" },
                    { new Guid("8bc047a7-1004-4449-9f3a-20bc9f11991a"), 0, "Drop A (7-string)", 7, "A E A D G B e" },
                    { new Guid("948bf3ce-ddf3-4a10-95e8-109826be9040"), 0, "A Standard (7-string)", 7, "A D G C F A D" },
                    { new Guid("97647eaf-8cd0-409f-a67a-d7ce18343ec8"), 0, "Drop G (7-string)", 7, "G D G C F A d" },
                    { new Guid("988cfe9e-f917-485c-bb79-7171267434ad"), 0, "G Standard (7-string)", 7, "G C F A# D# G C" },
                    { new Guid("99ad2f63-d8b9-4d25-af6b-aea917cf9dc0"), 0, "Open C (7-string)", 7, "G C G C G C E" },
                    { new Guid("a78e83f3-ca52-468d-97e2-eea510662e92"), 0, "G C G C F A D (7-string)", 7, "G C G C F A D" },
                    { new Guid("a80671d2-d9a5-41f5-9fff-c12103229964"), 0, "Drop E (7-string)", 7, "E B E A D G B" },
                    { new Guid("ab10dac0-2d86-4133-8885-8848a714d3bf"), 0, "Standard (8-string)", 8, "F# B E A D G B e" },
                    { new Guid("ac81e787-10d3-4239-b508-b80f99465d53"), 0, "F Standard (8-string)", 8, " F A# G# C# F# A# d#" },
                    { new Guid("b710fd85-0b82-4d49-a0a0-89d7b07cb63b"), 0, "E Standard (8-string)", 8, "E A D G C F A D" },
                    { new Guid("c2f0cc51-bec7-4410-8c35-5dbcf8c105c3"), 0, "D# Standard (8-string)", 8, "D# G# C# F# B E G# d" },
                    { new Guid("cb838df9-4526-4a80-80dc-7daf1e60483a"), 0, "A Standard (8-string)", 8, "A D G C F A D G" },
                    { new Guid("ce42be43-bc04-4cdd-8909-0eafaef42172"), 0, "Drop E (8-string)", 8, "E B E A D G B e" },
                    { new Guid("d0291a4d-dee4-4ae9-8507-ebb0141be85b"), 0, "Drop D# (8-string)", 8, "D# A# D# G# C# F# A# d#" },
                    { new Guid("e156fbbd-ca8b-4f45-b239-1cf011df0d93"), 0, "Drop D (8-string)", 8, "D A D G C F A d" },
                    { new Guid("e2fb00a8-3cec-48f4-964d-d4760fb672b4"), 1, "Bass Standard", 4, "E A D G" },
                    { new Guid("eb15e7fb-a632-43cf-9abc-27770ea0b3b3"), 1, "Bass Drop D", 4, "D A D G" },
                    { new Guid("ebe01503-1d1b-4116-a8c7-3cd1625507fa"), 1, "Bass D Standard", 4, "D G C F" },
                    { new Guid("ee8fd1a2-b5e4-43a6-abf4-66ccc963989f"), 1, "Bass Drop C", 4, "C G C F" },
                    { new Guid("f8fd50f6-815a-48db-a4d1-eb07c9f86ce2"), 1, "Bass C tuned to thirds", 4, "C F C G" },
                    { new Guid("fb3d4d5b-9d2b-4656-b3f1-2d024899e1ad"), 1, "5-string Bass Standard", 5, "B E A D G" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tunings_Name_Strings",
                table: "Tunings",
                columns: new[] { "Name", "Strings" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId_SongNumberInAlbum",
                table: "Songs",
                columns: new[] { "AlbumId", "SongNumberInAlbum" },
                unique: true,
                filter: "[SongNumberInAlbum] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Songs_SongId",
                table: "Tabs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_Songs_SongId",
                table: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Tunings_Name_Strings",
                table: "Tunings");

            migrationBuilder.DropIndex(
                name: "IX_Songs_AlbumId_SongNumberInAlbum",
                table: "Songs");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("00ba4053-f280-485a-8c91-6e68a5811670"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("06f3a378-1466-4dce-be31-d07bce66b3bf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("126a86a1-def6-4d44-9917-b4e23b532502"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("143aa742-966b-4c14-8a3e-45e188e8db88"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1792b587-515c-4a74-a63c-3cf23b643e4a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1bd4fd5e-8906-4e61-8b47-2894a187b218"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1e295e89-65a8-4d97-b0bb-8a86b8848dbf"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("20d40963-af4b-446e-b56f-88fed4f7ccc5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("29d81cde-da70-4163-b950-decd69e25f35"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("29ebba88-99a8-4c77-8913-648a4960fbdc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2b365e69-6d14-4158-adca-e61bc4b6ea1d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2d27174e-6cea-4aed-aea3-795e67a3b6af"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("2e7a36be-ffb0-4966-b283-c61ec7da62ae"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("311c94c8-f483-4a6e-8f1b-277d9c6d9d6e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("352e4e24-e6d6-4252-a03d-ef59ad1ec24f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3575068a-c9cf-48d5-9863-c8a51bded998"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3610eea6-f7ed-45ba-ac7e-c12428216b66"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("36b06ce2-4398-4d86-ac2e-85d6671cd65a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("392e5b99-789f-4a3f-8e62-12b7fa49b50d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("39d8b25d-c0b8-480b-9fc4-89b8ac6f4d2e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3a41bba1-de93-4a60-b73c-e6f4c116c974"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3b48b284-d160-4902-8157-351af90b7dea"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3e15d1dd-4a5e-43ed-903f-5265eef916ab"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4b2ce0e5-7ad9-4d49-bbdd-18df8bcd89ac"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4ca16a7b-6d34-4b1a-a712-ba1de65f0490"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("4ea6c397-a74a-454b-96cd-5c332b06a05f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5361222c-0e8a-485b-96e6-84758a1f8cf8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5915e7e0-abaa-4448-a38a-11dc5bba281a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("61079d22-1773-4f62-a094-dae968ec2523"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("67762cf4-91c2-4bb2-995c-2279f4959f39"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("688672b4-d039-472d-8f68-0b16b4d21099"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("69fbc41b-e2a5-4ee1-a5d6-a901b5ecd2c5"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6ac4cd9e-0eac-4397-931a-87c59aadcf3f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6dd672ed-f2d6-4496-ac35-26535fb64933"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("708d1a13-398e-4b7a-951a-344443762a20"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7303ac90-d829-4eaa-b875-e84789befb20"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("7342426b-440f-48ba-b559-a0ec1dce7918"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("75ac8f78-af29-4907-897d-569b200f5b70"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("78bd8712-345a-420a-adfe-755ebbaca901"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("79f91a8e-f9ca-48d7-83e9-501e957079de"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("806c90ad-5dfc-4dd8-b0d6-504bed981cb7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("823ff86e-c1b4-4adc-b3be-381a6445e01d"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("89c7935d-cbd3-40e1-bddb-5471c3c65d26"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8c299b0d-f492-4493-9971-6274f3df72d8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8ee31aa9-9992-4b73-8a46-fc8260dc1d52"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9088cf8e-ba8a-4d04-87e9-f8c6b28072a1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("933f74f0-2dad-4f18-aa3c-4cb7c2b4e31f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("94608f06-bbba-483c-a874-5d73a6a86819"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("94f2dd00-fa92-4d1a-ba9a-a91f5c5e87a2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9818250b-8943-4dda-9773-70976f0f5e63"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("9eb79154-d693-442d-9f3a-5851d5bd409c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a2e791b8-f76b-417a-89fa-944e941e71d3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a3afcbd3-58a7-41c8-a14a-1b2ab7c2af4a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a530cf67-2101-4957-807a-11de50385706"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a7206a81-c107-49b9-83b0-49cd6bd50b77"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a8c63f3f-bd3e-4b24-bc51-bdda58dfdcff"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ac0dcd5b-57e2-4033-bb64-5ea8387af0ee"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bc0eaa4c-4286-4f64-84bf-01a6dd8ec550"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("bdb370ea-2bc7-4ab9-ba3b-50f15d642444"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("be9f2922-505b-4548-9dd5-dd83e8511f50"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c9672803-489c-4041-a847-e0882812f9ba"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("c98ceb06-0e39-4401-af13-f8195588c612"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cbfcd2ee-006e-405c-a68d-a324c3fc1fe2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cf0ece86-c9d5-4229-b256-d366a8a0a4e1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("cfb80e1c-efcd-4c0c-82da-5251e4b4bdba"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d021debb-afd8-4020-ad69-87a845200ac3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d1ef7caf-3c8f-442b-baa7-741449cdbb52"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("d76f547c-cb1a-483c-9c36-299d49ab6eea"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ec973518-563a-4963-839d-d52add39c0ac"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("edbbc352-9d5f-402a-839b-0b0e45626f32"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ef9ec3d2-8781-4943-8aee-fafd726dc927"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("efa82c71-9fc2-49d2-b1b5-a0afc242c928"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f227bdf6-ae97-476c-adbf-f36fdd9eac11"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f30ee2f7-4372-4e72-a59d-790f1274a3e3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f38533e8-cb20-4fb4-b7ff-0b2158d9cc1e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f63b8ea6-617a-4ec7-81fb-ccba1c55211b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f6992f76-c8a2-4485-97db-628d793b84df"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f6d9b483-53ac-4ba1-93c1-0cc3cfade0e6"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f9918a17-66f3-4eaa-8a95-110034717541"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fa1c9b62-b6bc-4f07-a825-a852e34769a1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fa6a53ff-0fa2-4518-a3af-6bc4cd332ae8"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fbc655a7-8125-4ed4-81f9-0c69d8a74685"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("fccc9965-3505-457a-b361-a931dbb20d5c"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("007820a3-4221-4509-b414-81f2f8fa3705"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("14187d55-d884-4d57-a9ad-0964b214dc05"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("182603d3-0d82-4d14-815b-49bad0e4691e"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("19a4fe53-0739-4324-a3f5-6164b4603b69"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("2247d32f-6903-468c-9f3a-fd31baa3f194"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("251d6db3-8014-4ab8-a12c-27740dc99b41"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("37bffc99-476b-40b9-b1cd-187b302b3852"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("38be4d1b-ceec-4f21-9183-e87327e3dd3a"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("39dd5a87-ed95-467b-ba8b-2f72013aa028"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("3a83823c-b1b1-4b8b-b5d2-48a8aa8dc4ee"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("4dde6b18-553d-42e8-ade2-d084385e4e37"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("50f230ac-dae4-4d8d-863d-535f24c8d4d8"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("59bae8a1-6c22-4f43-b0a7-a8a58e98d501"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("5c873434-d0f1-494f-8533-6352fffbdd99"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("5e582416-47b7-488d-8958-251d84c77220"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("65fb8820-670f-4cba-9cfd-8cb93b734428"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("66eb5696-a633-45d2-a9d4-c52ac8748b0c"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("68133730-6b9a-4729-9139-f87af0b79464"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("8bc047a7-1004-4449-9f3a-20bc9f11991a"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("948bf3ce-ddf3-4a10-95e8-109826be9040"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("97647eaf-8cd0-409f-a67a-d7ce18343ec8"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("988cfe9e-f917-485c-bb79-7171267434ad"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("99ad2f63-d8b9-4d25-af6b-aea917cf9dc0"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("a78e83f3-ca52-468d-97e2-eea510662e92"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("a80671d2-d9a5-41f5-9fff-c12103229964"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("ab10dac0-2d86-4133-8885-8848a714d3bf"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("ac81e787-10d3-4239-b508-b80f99465d53"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("b710fd85-0b82-4d49-a0a0-89d7b07cb63b"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("c2f0cc51-bec7-4410-8c35-5dbcf8c105c3"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("cb838df9-4526-4a80-80dc-7daf1e60483a"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("ce42be43-bc04-4cdd-8909-0eafaef42172"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("d0291a4d-dee4-4ae9-8507-ebb0141be85b"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("e156fbbd-ca8b-4f45-b239-1cf011df0d93"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("e2fb00a8-3cec-48f4-964d-d4760fb672b4"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("eb15e7fb-a632-43cf-9abc-27770ea0b3b3"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("ebe01503-1d1b-4116-a8c7-3cd1625507fa"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("ee8fd1a2-b5e4-43a6-abf4-66ccc963989f"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("f8fd50f6-815a-48db-a4d1-eb07c9f86ce2"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("fb3d4d5b-9d2b-4656-b3f1-2d024899e1ad"));

            migrationBuilder.DropColumn(
                name: "AlbumType",
                table: "Albums");

            migrationBuilder.CreateIndex(
                name: "IX_Tunings_Name",
                table: "Tunings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tunings_Strings",
                table: "Tunings",
                column: "Strings",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_Songs_SongId",
                table: "Tabs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id");
        }
    }
}
