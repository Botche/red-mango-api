namespace RedMangoAPI.Database.SeedsData
{
    using RedMangoAPI.Database.Entities;

    public static class MenuItemSeed
    {
        public static readonly ICollection<MenuItem> MenuItems = new MenuItem[] {
            new MenuItem
            {
                Id = Guid.Parse("104426E1-4E45-4625-89FB-8F898515F68C"),
                Name = "Spring Roll",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/spring roll.jpg",
                Price = 7.99,
                Category = "Appetizer",
                SpecialTag = ""
            },
            new MenuItem
            {
                Id = Guid.Parse("FDB42B85-2A67-4724-84B0-DB2AC52C005F"),
                Name = "Idli",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/idli.jpg",
                Price = 8.99,
                Category = "Appetizer",
                SpecialTag = ""
            },
            new MenuItem
            {
                Id = Guid.Parse("5ABDEAC3-82D6-47EF-8B1E-AEF268EA5F10"),
                Name = "Panu Puri",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/pani puri.jpg",
                Price = 8.99,
                Category = "Appetizer",
                SpecialTag = "Best Seller"
            },
            new MenuItem
            {
                Id = Guid.Parse("DBA174E5-4E69-4ACC-A269-278840181F88"),
                Name = "Hakka Noodles",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/hakka noodles.jpg",
                Price = 10.99,
                Category = "Entrée",
                SpecialTag = ""
            },
            new MenuItem
            {
                Id = Guid.Parse("EEF6238C-13F4-44D6-B1FC-B07B8424D110"),
                Name = "Malai Kofta",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/malai kofta.jpg",
                Price = 12.99,
                Category = "Entrée",
                SpecialTag = "Top Rated"
            },
            new MenuItem
            {
                Id = Guid.Parse("C1D9006C-CA4C-447A-83CF-9F0B0AB4D419"),
                Name = "Paneer Pizza",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/paneer pizza.jpg",
                Price = 11.99,
                Category = "Entrée",
                SpecialTag = ""
            },
            new MenuItem
            {
                Id = Guid.Parse("1DF86D99-747F-4323-8E9B-52136E18480D"),
                Name = "Paneer Tikka",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/paneer tikka.jpg",
                Price = 13.99,
                Category = "Entrée",
                SpecialTag = "Chef's Special"
            },
            new MenuItem
            {
                Id = Guid.Parse("4D17417F-7215-4113-8F72-12A5744210B5"),
                Name = "Carrot Love",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/carrot love.jpg",
                Price = 4.99,
                Category = "Dessert",
                SpecialTag = ""
            },
            new MenuItem
            {
                Id = Guid.Parse("4EDF5806-6B39-40B8-B663-F17D068EEA13"),
                Name = "Rasmalai",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/rasmalai.jpg",
                Price = 4.99,
                Category = "Dessert",
                SpecialTag = "Chef's Special"
            },
            new MenuItem
            {
                Id = Guid.Parse("F996D76B-F077-4043-8AD2-0E11F0168F78"),
                Name = "Sweet Rolls",
                Description = "Fusc tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://redmagostorageimages.blob.core.windows.net/redmango/sweet rolls.jpg",
                Price = 3.99,
                Category = "Dessert",
                SpecialTag = "Top Rated"
            }
        };
    }
}
