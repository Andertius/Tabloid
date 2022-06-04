using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabloid.Infrastructure.Migrations
{
    public partial class AddDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new Guid("02cd609b-3a68-42fc-9f0f-bbc37b9a0e9f"), 0, "E Standard (8-string)", 8, "E A D G C F A D" });

            migrationBuilder.InsertData(
                table: "Tunings",
                columns: new[] { "Id", "Instrument", "Name", "StringNumber", "Strings" },
                values: new object[,]
                {
                    { new Guid("03938ad0-3aad-4021-838d-a14cc974275e"), 0, "Open C (7-string)", 7, "G C G C G C E" },
                    { new Guid("0642aa55-dcce-49b5-b9e7-6d7b2793d0b3"), 0, "Drop A#", 6, "A# F A# D# G c" },
                    { new Guid("092af51d-c7da-4ec7-8782-527112093600"), 0, "Drop B", 6, "B F# B E G# C#" },
                    { new Guid("1949a3e3-c8a1-42c5-92b3-018cda2879b0"), 0, "Drop C", 6, "C G C F A D" },
                    { new Guid("198e52a8-addb-455e-b1c9-abe2dbd5ff80"), 0, "Standard (8-string)", 8, "F# B E A D G B e" },
                    { new Guid("1b9e3380-5905-413f-9ee9-03fdba8ec50d"), 0, "Standard (7-string)", 7, "B E A D G B e" },
                    { new Guid("1c05a351-92b5-46ab-972a-64f41b1eb69b"), 1, "5-string Bass Standard", 5, "B E A D G" },
                    { new Guid("35e41458-e204-4946-82b8-65dd51b6724b"), 0, "Drop D# (8-string)", 8, "D# A# D# G# C# F# A# d#" },
                    { new Guid("3d1be9c7-81f5-4b88-bd05-29485a8a8136"), 0, "A Standard (8-string)", 8, "A D G C F A D G" },
                    { new Guid("402a9c32-1c43-41c8-8801-18b1b4a9a936"), 0, "Drop A", 6, "A E A D F# b" },
                    { new Guid("443b7aa5-7ce7-4820-bced-07f571fa9de6"), 0, "D Standard", 6, "D G C F A d" },
                    { new Guid("44e2cf1f-df33-45b8-852d-1277eae522a8"), 1, "Bass Drop D", 4, "D A D G" },
                    { new Guid("4b210eef-9933-4eb7-b4b5-c0aeab64ba27"), 1, "Bass Standard", 4, "E A D G" },
                    { new Guid("55e470f3-1717-488d-ac0c-fd28dd0fc7d1"), 0, "F Standard (8-string)", 8, " F A# G# C# F# A# d#" },
                    { new Guid("56e5a0c5-9ba0-4d21-b94c-818808a6222b"), 0, "Standard", 6, "E A D G B e" },
                    { new Guid("6fa80499-4a60-48ac-879f-af3e1b04971e"), 0, "G C G C F A D (7-string)", 7, "G C G C F A D" },
                    { new Guid("75ecf4ff-66f1-42e3-bdf2-e97da11e99aa"), 0, "Drop D", 6, "D A D G B E" },
                    { new Guid("7ca1b4ae-106d-4469-83c3-670ad778abbe"), 0, "Drop C#", 6, "C# G# C# F# A# D#" },
                    { new Guid("835bed98-6e3c-4d6c-8d76-dfd7bc5444af"), 0, "B Standard", 6, "B E A D F# b" },
                    { new Guid("8a5a6783-40df-467f-957b-bb2ae731ed4d"), 1, "6-string Bass Standard", 5, "B E A D G C" },
                    { new Guid("916abb59-5385-403a-bcfe-193c0d35ec8b"), 0, "A# Standard (7-string)", 7, "A# G# C# F# A# d#" },
                    { new Guid("9dc963f4-f08b-404b-9314-010ded3aaabd"), 0, "Drop E (7-string)", 7, "E B E A D G B" },
                    { new Guid("a8630e44-8bfc-4dbf-bd7c-01d13763d504"), 0, "G Standard (7-string)", 7, "G C F A# D# G C" },
                    { new Guid("aa2d36cf-17c9-41c9-8ff6-01f4525b700b"), 0, "Drop A (7-string)", 7, "A E A D G B e" },
                    { new Guid("afc48f1a-c68d-4984-970d-037cd9b61ac3"), 1, "Bass D Standard", 4, "D G C F" },
                    { new Guid("c18bfdd6-11e2-4ccc-bb8b-0e621e4c1a91"), 0, "A Standard", 6, "A D G C E a" },
                    { new Guid("cc08baf9-0920-4b2a-90ae-c03b8a744490"), 0, "A Standard (7-string)", 7, "A D G C F A D" },
                    { new Guid("d1b7cf50-e07f-46b5-88cc-2bce96169579"), 1, "Bass C tuned to thirds", 4, "C F C G" },
                    { new Guid("d94c8f44-be87-4e82-8e56-4006eb090bf2"), 0, "D# Standard (8-string)", 8, "D# G# C# F# B E G# d" },
                    { new Guid("db70492e-b7cc-4b18-893b-754ac6aa11f9"), 0, "A# Standard", 6, "A# D# G# C# F a#" },
                    { new Guid("df9bc326-2e5f-4547-9937-4a2a12b010f6"), 0, "C# Standard", 6, "C# F# B E G# c#" },
                    { new Guid("e4c7369e-e2df-4659-ad50-c01813395227"), 0, "G G C F A d", 6, "G G C F A d" },
                    { new Guid("ef43cb7e-518b-499d-a3f0-598921463bea"), 0, "Drop G (7-string)", 7, "G D G C F A d" },
                    { new Guid("f05291cd-aa6f-4201-9649-81c6fb10e603"), 0, "Drop D (8-string)", 8, "D A D G C F A d" },
                    { new Guid("f3d8ddd3-59a6-4c4f-924e-124261a04852"), 0, "C Standard", 6, "C F A# D# G c" },
                    { new Guid("f7fee790-bae6-4f10-8247-b840afbe9e69"), 0, "Drop E (8-string)", 8, "E B E A D G B e" },
                    { new Guid("fbc8747e-bf8f-471b-81a4-148fb629717e"), 1, "Bass Drop C", 4, "C G C F" },
                    { new Guid("fefd4bdb-1b6c-41e2-9e96-9c5eb85b2063"), 0, "D# Standard", 6, "D# G# C# F# A# d#" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("02cd609b-3a68-42fc-9f0f-bbc37b9a0e9f"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("03938ad0-3aad-4021-838d-a14cc974275e"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("0642aa55-dcce-49b5-b9e7-6d7b2793d0b3"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("092af51d-c7da-4ec7-8782-527112093600"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("1949a3e3-c8a1-42c5-92b3-018cda2879b0"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("198e52a8-addb-455e-b1c9-abe2dbd5ff80"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("1b9e3380-5905-413f-9ee9-03fdba8ec50d"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("1c05a351-92b5-46ab-972a-64f41b1eb69b"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("35e41458-e204-4946-82b8-65dd51b6724b"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("3d1be9c7-81f5-4b88-bd05-29485a8a8136"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("402a9c32-1c43-41c8-8801-18b1b4a9a936"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("443b7aa5-7ce7-4820-bced-07f571fa9de6"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("44e2cf1f-df33-45b8-852d-1277eae522a8"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("4b210eef-9933-4eb7-b4b5-c0aeab64ba27"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("55e470f3-1717-488d-ac0c-fd28dd0fc7d1"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("56e5a0c5-9ba0-4d21-b94c-818808a6222b"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("6fa80499-4a60-48ac-879f-af3e1b04971e"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("75ecf4ff-66f1-42e3-bdf2-e97da11e99aa"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("7ca1b4ae-106d-4469-83c3-670ad778abbe"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("835bed98-6e3c-4d6c-8d76-dfd7bc5444af"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("8a5a6783-40df-467f-957b-bb2ae731ed4d"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("916abb59-5385-403a-bcfe-193c0d35ec8b"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("9dc963f4-f08b-404b-9314-010ded3aaabd"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("a8630e44-8bfc-4dbf-bd7c-01d13763d504"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("aa2d36cf-17c9-41c9-8ff6-01f4525b700b"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("afc48f1a-c68d-4984-970d-037cd9b61ac3"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("c18bfdd6-11e2-4ccc-bb8b-0e621e4c1a91"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("cc08baf9-0920-4b2a-90ae-c03b8a744490"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("d1b7cf50-e07f-46b5-88cc-2bce96169579"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("d94c8f44-be87-4e82-8e56-4006eb090bf2"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("db70492e-b7cc-4b18-893b-754ac6aa11f9"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("df9bc326-2e5f-4547-9937-4a2a12b010f6"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("e4c7369e-e2df-4659-ad50-c01813395227"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("ef43cb7e-518b-499d-a3f0-598921463bea"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("f05291cd-aa6f-4201-9649-81c6fb10e603"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("f3d8ddd3-59a6-4c4f-924e-124261a04852"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("f7fee790-bae6-4f10-8247-b840afbe9e69"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("fbc8747e-bf8f-471b-81a4-148fb629717e"));

            migrationBuilder.DeleteData(
                table: "Tunings",
                keyColumn: "Id",
                keyValue: new Guid("fefd4bdb-1b6c-41e2-9e96-9c5eb85b2063"));
        }
    }
}
