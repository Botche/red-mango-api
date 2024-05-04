using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedMangoAPI.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("104426e1-4e45-4625-89fb-8f898515f68c"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858705/red-mango/spring-roll.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("1df86d99-747f-4323-8e9b-52136e18480d"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858704/red-mango/paneer-tikka.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("4d17417f-7215-4113-8f72-12a5744210b5"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858704/red-mango/carrot-love.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("4edf5806-6b39-40b8-b663-f17d068eea13"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714859161/red-mango/rasmalai.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("5abdeac3-82d6-47ef-8b1e-aef268ea5f10"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858705/red-mango/pani-puri.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c1d9006c-ca4c-447a-83cf-9f0b0ab4d419"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858704/red-mango/paneer-pizza.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("dba174e5-4e69-4acc-a269-278840181f88"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858704/red-mango/hakka-noodles.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("eef6238c-13f4-44d6-b1fc-b07b8424d110"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858704/red-mango/malai-kofta.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f996d76b-f077-4043-8ad2-0e11f0168f78"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858705/red-mango/sweet-rolls.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("fdb42b85-2a67-4724-84b0-db2ac52c005f"),
                column: "ImageUrl",
                value: "https://res.cloudinary.com/djlskbceh/image/upload/v1714858704/red-mango/idli.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("104426e1-4e45-4625-89fb-8f898515f68c"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/spring roll.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("1df86d99-747f-4323-8e9b-52136e18480d"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/paneer tikka.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("4d17417f-7215-4113-8f72-12a5744210b5"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/carrot love.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("4edf5806-6b39-40b8-b663-f17d068eea13"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/rasmalai.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("5abdeac3-82d6-47ef-8b1e-aef268ea5f10"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/pani puri.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c1d9006c-ca4c-447a-83cf-9f0b0ab4d419"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/paneer pizza.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("dba174e5-4e69-4acc-a269-278840181f88"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/hakka noodles.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("eef6238c-13f4-44d6-b1fc-b07b8424d110"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/malai kofta.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f996d76b-f077-4043-8ad2-0e11f0168f78"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/sweet rolls.jpg");

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("fdb42b85-2a67-4724-84b0-db2ac52c005f"),
                column: "ImageUrl",
                value: "https://redmagostorageimages.blob.core.windows.net/redmango/idli.jpg");
        }
    }
}
