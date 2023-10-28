using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RedMangoAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { new Guid("104426e1-4e45-4625-89fb-8f898515f68c"), "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/spring roll.jpg", "Spring Roll", 7.9900000000000002, "" },
                    { new Guid("1df86d99-747f-4323-8e9b-52136e18480d"), "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/paneer tikka.jpg", "Paneer Tikka", 13.99, "Chef's Special" },
                    { new Guid("4d17417f-7215-4113-8f72-12a5744210b5"), "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/carrot love.jpg", "Carrot Love", 4.9900000000000002, "" },
                    { new Guid("4edf5806-6b39-40b8-b663-f17d068eea13"), "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/rasmalai.jpg", "Rasmalai", 4.9900000000000002, "Chef's Special" },
                    { new Guid("5abdeac3-82d6-47ef-8b1e-aef268ea5f10"), "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/pani puri.jpg", "Panu Puri", 8.9900000000000002, "Best Seller" },
                    { new Guid("c1d9006c-ca4c-447a-83cf-9f0b0ab4d419"), "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/paneer pizza.jpg", "Paneer Pizza", 11.99, "" },
                    { new Guid("dba174e5-4e69-4acc-a269-278840181f88"), "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/hakka noodles.jpg", "Hakka Noodles", 10.99, "" },
                    { new Guid("eef6238c-13f4-44d6-b1fc-b07b8424d110"), "Entrée", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/malai kofta.jpg", "Malai Kofta", 12.99, "Top Rated" },
                    { new Guid("f996d76b-f077-4043-8ad2-0e11f0168f78"), "Dessert", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/sweet rolls.jpg", "Sweet Rolls", 3.9900000000000002, "Top Rated" },
                    { new Guid("fdb42b85-2a67-4724-84b0-db2ac52c005f"), "Appetizer", "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://redmagostorageimages.blob.core.windows.net/redmango/idli.jpg", "Idli", 8.9900000000000002, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("104426e1-4e45-4625-89fb-8f898515f68c"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("1df86d99-747f-4323-8e9b-52136e18480d"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("4d17417f-7215-4113-8f72-12a5744210b5"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("4edf5806-6b39-40b8-b663-f17d068eea13"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("5abdeac3-82d6-47ef-8b1e-aef268ea5f10"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c1d9006c-ca4c-447a-83cf-9f0b0ab4d419"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("dba174e5-4e69-4acc-a269-278840181f88"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("eef6238c-13f4-44d6-b1fc-b07b8424d110"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f996d76b-f077-4043-8ad2-0e11f0168f78"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("fdb42b85-2a67-4724-84b0-db2ac52c005f"));
        }
    }
}
