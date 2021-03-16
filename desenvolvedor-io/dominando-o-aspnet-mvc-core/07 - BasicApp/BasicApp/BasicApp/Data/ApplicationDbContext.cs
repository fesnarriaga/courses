using BasicApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Production> Productions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<Product> Products { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }
        //public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Seed Data

            var movies = new[] {
                new Movie
                {
                    Id = Guid.Parse("a669c9e6-5cfe-44cf-a27e-4a07ec71678e"),
                    Name = "Avengers: Endgame",
                    WorldwideBoxOfficeGross = 2_797_800_564,
                    DurationInMinutes = 181,
                    ReleaseDate = new DateTime(2019, 4, 26)
                },
                new Movie
                {
                    Id = Guid.Parse("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"),
                    Name = "The Lion King",
                    WorldwideBoxOfficeGross = 1_654_791_102,
                    DurationInMinutes     = 118,
                    ReleaseDate = new DateTime(2019, 7, 19)
                },
                new Movie
                {
                    Id = Guid.Parse("c726bf0e-79ab-4e81-9825-b30b690ba77f"),
                    Name = "Ip Man 4",
                    WorldwideBoxOfficeGross = 192_617_891,
                    DurationInMinutes = 105,
                    ReleaseDate = new DateTime(2019, 12, 25)
                },
                new Movie
                {
                    Id = Guid.Parse("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5"),
                    Name = "Gemini Man",
                    WorldwideBoxOfficeGross = 166_623_705,
                    DurationInMinutes = 116,
                    ReleaseDate = new DateTime(2019, 11, 20)
                },
                new Movie
                {
                    Id = Guid.Parse("594c3c95-71b5-497c-b8c1-cceb61ba55b2"),
                    Name = "Downton Abbey",
                    WorldwideBoxOfficeGross = 194_051_302,
                    DurationInMinutes = 120,
                    ReleaseDate = new DateTime(2020, 9, 20 )
                }
            };

            var series = new[] {
                new Series
                {
                    Id = Guid.Parse("9dead2c1-a458-4fac-911f-f75b43dabb4c"),
                    Name = "The Fresh Prince of Bel-Air",
                    NumberOfEpisodes = 148,
                    ReleaseDate = new DateTime(1990, 9, 10)
                },
                new Series
                {
                    Id = Guid.Parse("373914c9-b99f-48ff-a4ef-5486b1499b74"),
                    Name = "Downton Abbey",
                    NumberOfEpisodes = 52,
                    ReleaseDate = new DateTime(2010, 09, 26)
                },
                new Series
                {
                    Id = Guid.Parse("96837c11-5528-4fab-9285-d4bd11b72a3d"),
                    Name = "Stranger Things",
                    NumberOfEpisodes = 34 ,
                    ReleaseDate = new DateTime(2016, 7, 11)
                },
                new Series
                {
                    Id = Guid.Parse("a007ab4a-a257-409a-a32c-a5a3a1e053ed"),
                    Name = "Kantaro: The Sweet Tooth Salaryman",
                    NumberOfEpisodes = 12,
                    ReleaseDate = new DateTime(2017,7, 14)
                },
                new Series
                {
                    Id = Guid.Parse("2d83a109-1fb4-4f63-98d5-f838bdd73d98"),
                    Name = "The Walking Dead",
                    NumberOfEpisodes = 177 ,
                    ReleaseDate = new DateTime(2010, 10, 31)
                }
            };

            var productions = movies
                .Cast<Production>()
                .Union(series)
                .ToList();

            builder.Entity<Movie>().HasData(movies);
            builder.Entity<Series>().HasData(series);

            builder.Entity<Character>().HasData(
                new Character
                {
                    Id = Guid.Parse("a4fe1159-01ff-430c-9059-20926501a4d3"),
                    Name = "Tony Stark",
                    ProductionId = Guid.Parse("a669c9e6-5cfe-44cf-a27e-4a07ec71678e"),
                    ActorId = Guid.Parse("0aadf706-0eae-478e-8dd9-d337463920d7")
                },
                new Character
                {
                    Id = Guid.Parse("ba3d2449-3ec3-4308-a9bc-2fcdd352459a"),
                    Name = "Steve Rogers",
                    ProductionId = Guid.Parse("a669c9e6-5cfe-44cf-a27e-4a07ec71678e"),
                    ActorId = Guid.Parse("a044553d-f3c0-48c2-8ded-160b409b5203")
                },
                new Character
                {
                    Id = Guid.Parse("b3f18f9a-bf4d-4236-93a4-7318c189b864"),
                    Name = "Okoye",
                    ProductionId = Guid.Parse("a669c9e6-5cfe-44cf-a27e-4a07ec71678e"),
                    ActorId = Guid.Parse("ec80a220-3c9d-498f-bbcf-d02a60389fa4")
                },
                new Character
                {
                    Id = Guid.Parse("e2c339da-6533-47cb-937c-c58bbe4ff096"),
                    Name = "Simba",
                    ProductionId = Guid.Parse("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"),
                    ActorId = Guid.Parse("065a4f10-e46d-4502-ade8-f37d72d64d3b")
                },
                new Character
                {
                    Id = Guid.Parse("43a4e0b1-3a3f-4ae8-8e2d-77c0c822141c"),
                    Name = "Nala",
                    ProductionId = Guid.Parse("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"),
                    ActorId = Guid.Parse("42defd05-818c-427b-a1ef-94b5e15d8256")
                },
                new Character
                {
                    Id = Guid.Parse("e2f1e8cd-4d7d-4ec6-ae05-b0251f89f60d"),
                    Name = "Ip Man",
                    ProductionId = Guid.Parse("c726bf0e-79ab-4e81-9825-b30b690ba77f"),
                    ActorId = Guid.Parse("a6a84308-efab-4f1d-b9c7-eab696f91f0a")
                },
                new Character
                {
                    Id = Guid.Parse("07c880ab-73e4-4636-9d5c-749152ea3923"),
                    Name = "Henry Brogan",
                    ProductionId = Guid.Parse("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5"),
                    ActorId = Guid.Parse("3e9c60ac-9b0a-45bd-8a34-b17c09d5edae")
                },
                new Character
                {
                    Id = Guid.Parse("b00ad210-f917-4c20-bc5f-03be6f8f6540"),
                    Name = "Violet Crawley",
                    ProductionId = Guid.Parse("594c3c95-71b5-497c-b8c1-cceb61ba55b2"),
                    ActorId = Guid.Parse("fad15e86-fb5c-4706-b3bd-97add48e77e1")
                },
                new Character
                {
                    Id = Guid.Parse("fbbc4e14-4d23-4414-ba19-4932a2c6adff"),
                    Name = "Lady Mary Crawley",
                    ProductionId = Guid.Parse("594c3c95-71b5-497c-b8c1-cceb61ba55b2"),
                    ActorId = Guid.Parse("42a9f2dc-ed81-47bc-86c9-37eab07352bf")
                },
                new Character
                {
                    Id = Guid.Parse("800afaf3-6a13-4be0-9e36-f8c4848c48f8"),
                    Name = "Will Smith",
                    ProductionId = Guid.Parse("9dead2c1-a458-4fac-911f-f75b43dabb4c"),
                    ActorId = Guid.Parse("3e9c60ac-9b0a-45bd-8a34-b17c09d5edae")
                },
                new Character
                {
                    Id = Guid.Parse("2f83add8-6242-43aa-82f0-2a16cbdb7890"),
                    Name = "Hilary Banks",
                    ProductionId = Guid.Parse("9dead2c1-a458-4fac-911f-f75b43dabb4c"),
                    ActorId = Guid.Parse("10a8d4a0-c526-4dd5-860a-8c4c1fd007dc")
                },
                new Character
                {
                    Id = Guid.Parse("3b5e90d8-c25b-4b73-a889-121bdf0e6ef9"),
                    Name = "Violet Crawley",
                    ProductionId = Guid.Parse("373914c9-b99f-48ff-a4ef-5486b1499b74"),
                    ActorId = Guid.Parse("fad15e86-fb5c-4706-b3bd-97add48e77e1")
                },
                new Character
                {
                    Id = Guid.Parse("72e8841c-6370-4aa0-b48e-6b5373f133e1"),
                    Name = "Lady Mary Crawley",
                    ProductionId = Guid.Parse("373914c9-b99f-48ff-a4ef-5486b1499b74"),
                    ActorId = Guid.Parse("42a9f2dc-ed81-47bc-86c9-37eab07352bf")
                },
                new Character
                {
                    Id = Guid.Parse("6ed7e268-a25e-41a0-a12c-774e19d0a8e9"),
                    Name = "Eleven",
                    ProductionId = Guid.Parse("96837c11-5528-4fab-9285-d4bd11b72a3d"),
                    ActorId = Guid.Parse("75a094a6-4e2c-4ab9-9197-d98c49e05978")
                },
                new Character
                {
                    Id = Guid.Parse("9ff37dc2-16c9-4842-9a90-9c027e0f3820"),
                    Name = "Lucas",
                    ProductionId = Guid.Parse("96837c11-5528-4fab-9285-d4bd11b72a3d"),
                    ActorId = Guid.Parse("6d3d82ac-1115-444f-bcf8-0e0518174125")
                },
                new Character
                {
                    Id = Guid.Parse("e79cb17c-03ac-43cd-9d5c-634b46420dda"),
                    Name = "Joyce Byers",
                    ProductionId = Guid.Parse("96837c11-5528-4fab-9285-d4bd11b72a3d"),
                    ActorId = Guid.Parse("952c484e-383b-4a0e-9e23-090f01f3283f")
                },
                new Character
                {
                    Id = Guid.Parse("51d36164-2593-4ebf-97eb-05aca8946502"),
                    Name = "Jim Hopper",
                    ProductionId = Guid.Parse("96837c11-5528-4fab-9285-d4bd11b72a3d"),
                    ActorId = Guid.Parse("04ff0e91-2ed6-4200-9f7a-caa5b47e9d4b")
                },
                new Character
                {
                    Id = Guid.Parse("fde7b141-7112-47be-825b-ea348baff5fa"),
                    Name = "Ametani Kantarou",
                    ProductionId = Guid.Parse("a007ab4a-a257-409a-a32c-a5a3a1e053ed"),
                    ActorId = Guid.Parse("b23c7a12-2deb-4a3f-97f6-e6350f4665ff")
                },
                new Character
                {
                    Id = Guid.Parse("ae630bef-0bee-4cb1-842b-acfb63d53859"),
                    Name = "Sano Erika",
                    ProductionId = Guid.Parse("a007ab4a-a257-409a-a32c-a5a3a1e053ed"),
                    ActorId = Guid.Parse("3639dee6-db01-4a1f-b8d6-7f9800877feb")
                },
                new Character
                {
                    Id = Guid.Parse("a95365b4-f9af-44d5-9080-b195ea54280e"),
                    Name = "Daryl Dixon",
                    ProductionId = Guid.Parse("2d83a109-1fb4-4f63-98d5-f838bdd73d98"),
                    ActorId = Guid.Parse("9177780c-7fa2-46b4-8883-e85d68826a91")
                },
                new Character
                {
                    Id = Guid.Parse("aafae44d-08d1-4327-a1d3-ff4fdb2c1daf"),
                    Name = "Michonne",
                    ProductionId = Guid.Parse("2d83a109-1fb4-4f63-98d5-f838bdd73d98"),
                    ActorId = Guid.Parse("ec80a220-3c9d-498f-bbcf-d02a60389fa4")
                },
                new Character
                {
                    Id = Guid.Parse("709ff826-52ba-4a51-860e-43c65649ca72"),
                    Name = "Carol Peletier",
                    ProductionId = Guid.Parse("2d83a109-1fb4-4f63-98d5-f838bdd73d98"),
                    ActorId = Guid.Parse("418a16a7-3ead-4488-af7c-66110d391d87")
                });


            builder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = Guid.Parse("0aadf706-0eae-478e-8dd9-d337463920d7"),
                    Name = "Robert Downey Jr."
                },
                new Actor
                {
                    Id = Guid.Parse("a044553d-f3c0-48c2-8ded-160b409b5203"),
                    Name = "Chris Evans"
                },
                new Actor
                {
                    Id = Guid.Parse("ec80a220-3c9d-498f-bbcf-d02a60389fa4"),
                    Name = "Danai Guira"
                },
                new Actor
                {
                    Id = Guid.Parse("065a4f10-e46d-4502-ade8-f37d72d64d3b"),
                    Name = "Donald Glover"
                },
                new Actor
                {
                    Id = Guid.Parse("42defd05-818c-427b-a1ef-94b5e15d8256"),
                    Name = "Beyoncé"
                },
                new Actor
                {
                    Id = Guid.Parse("a6a84308-efab-4f1d-b9c7-eab696f91f0a"),
                    Name = "Donny Yen"
                },
                new Actor
                {
                    Id = Guid.Parse("3e9c60ac-9b0a-45bd-8a34-b17c09d5edae"),
                    Name = "Will Smith"
                },
                new Actor
                {
                    Id = Guid.Parse("fad15e86-fb5c-4706-b3bd-97add48e77e1"),
                    Name = "Maggie Smith"
                },
                new Actor
                {
                    Id = Guid.Parse("42a9f2dc-ed81-47bc-86c9-37eab07352bf"),
                    Name = "Michelle Dockery"
                },
                new Actor
                {
                    Id = Guid.Parse("10a8d4a0-c526-4dd5-860a-8c4c1fd007dc"),
                    Name = "Karyn Parsons"
                },
                new Actor
                {
                    Id = Guid.Parse("75a094a6-4e2c-4ab9-9197-d98c49e05978"),
                    Name = "Millie Bobby Brown"
                },
                new Actor
                {
                    Id = Guid.Parse("6d3d82ac-1115-444f-bcf8-0e0518174125"),
                    Name = "Caleb McLaughlin"
                },
                new Actor
                {
                    Id = Guid.Parse("952c484e-383b-4a0e-9e23-090f01f3283f"),
                    Name = "Winona Ryder"
                },
                new Actor
                {
                    Id = Guid.Parse("04ff0e91-2ed6-4200-9f7a-caa5b47e9d4b"),
                    Name = "David Harbour"
                },
                new Actor
                {
                    Id = Guid.Parse("b23c7a12-2deb-4a3f-97f6-e6350f4665ff"),
                    Name = "Matsuya Onoe"
                },
                new Actor
                {
                    Id = Guid.Parse("3639dee6-db01-4a1f-b8d6-7f9800877feb"),
                    Name = "Hazuki Shimizu"
                },
                new Actor
                {
                    Id = Guid.Parse("9177780c-7fa2-46b4-8883-e85d68826a91"),
                    Name = "Norman Reedus"
                },
                new Actor
                {
                    Id = Guid.Parse("418a16a7-3ead-4488-af7c-66110d391d87"),
                    Name = "Melissa McBride"
                });

            var random = new Random();
            var sources = new[] {
                "Internet",
                "Newspaper",
                "Magazine",
                "App"
            };

            var ratings = new List<Rating>();
            foreach (var production in productions)
            {
                var numberOfRatings = random.Next(2, 6);

                for (var i = 0; i < numberOfRatings; i++)
                {
                    ratings.Add(new Rating
                    {
                        Source = sources[random.Next(0, 4)],
                        Stars = random.Next(1, 6),
                        ProductionId = production.Id
                    });
                }
            }

            builder.Entity<Rating>().HasData(ratings);

            #endregion

            base.OnModelCreating(builder);
        }
    }
}
