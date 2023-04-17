using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Organizer
                if (!context.Organizers.Any())
                {
                    context.Organizers.AddRange(new List<Organizer>()
                    {
                        new Organizer()
                        {
                            Name = "IMAX Events",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the Organizer"
                        },
                        new Organizer()
                        {
                            Name = "Movie House Events",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the Organizer"
                        },
                        new Organizer()
                        {
                            Name = "Great Lakes",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the Organizer"
                        },
                        new Organizer()
                        {
                            Name = "State Tigers",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the Organizer"
                        },
                        new Organizer()
                        {
                            Name = "Nazareth Somerhalder",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the Organizer"
                        },
                    });
                    context.SaveChanges();
                }
                //Artists
                if (!context.Artists.Any())
                {
                    context.Artists.AddRange(new List<Artist>()
                    {
                        new Artist()
                        {
                            FullName = "Michelangelo",
                            Bio = "This is the Bio of the artist",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Artist()
                        {
                            FullName = "Vermeer",
                            Bio = "This is the Bio of the artist",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Artist()
                        {
                            FullName = "Eugene Delacroix",
                            Bio = "This is the Bio of the artist",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Artist()
                        {
                            FullName = "Leonardo da Vinci",
                            Bio = "This is the Bio of the artist",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Artist()
                        {
                            FullName = "Claude Monet",
                            Bio = "This is the Bio of the artist",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //FundRaisers
                if (!context.FundRaisers.Any())
                {
                    context.FundRaisers.AddRange(new List<FundRaiser>()
                    {
                        new FundRaiser()
                        {
                            FullName = "Moksh Sadhu",
                            Bio = "This is the Bio of the first FundRaiser",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new FundRaiser()
                        {
                            FullName = "Will Somehalder",
                            Bio = "This is the Bio of the FundRaiser",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new FundRaiser()
                        {
                            FullName = "Ankoor Singh",
                            Bio = "This is the Bio of the FundRaiser",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new FundRaiser()
                        {
                            FullName = "Moon Dsouza",
                            Bio = "This is the Bio of the FundRaiser",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new FundRaiser()
                        {
                            FullName = "Gren Will",
                            Bio = "This is the Bio of the FundRaiser",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Paintings
                if (!context.Paintings.Any())
                {
                    context.Paintings.AddRange(new List<Painting>()
                    {
                        new Painting()
                        {
                            Name = "Life Lessons Art",
                            Description = "This is the Life Lessons Art description",
                            Price = 3950,
                            ImageURL = "http://commondatastorage.googleapis.com/codeskulptor-assets/gutenberg.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            OrganizerId = 3,
                            FundRaiserId = 3,
                            PaintingCategory = PaintingCategory.Mandala
                        },
                        new Painting()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 2950,
                            ImageURL = "http://commondatastorage.googleapis.com/codeskulptor-assets/explosion.hasgraphics.png",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            OrganizerId = 1,
                            FundRaiserId = 1,
                            PaintingCategory = PaintingCategory.Action
                        },
                        new Painting()
                        {
                            Name = "Kala Kriti",
                            Description = "This is the Kala Kriti description",
                            Price = 2250,
                            ImageURL = "http://commondatastorage.googleapis.com/codeskulptor-assets/gutenberg.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            OrganizerId = 4,
                            FundRaiserId = 4,
                            PaintingCategory = PaintingCategory.Madubani
                        },
                        new Painting()
                        {
                            Name = "Arabian Art Exhibition",
                            Description = "This is the Arabian Art Exhibition description",
                            Price = 3290,
                            ImageURL = "http://commondatastorage.googleapis.com/codeskulptor-assets/explosion.hasgraphics.png",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            OrganizerId = 1,
                            FundRaiserId = 2,
                            PaintingCategory = PaintingCategory.Warli
                        },
                        new Painting()
                        {
                            Name = "Punch of Art",
                            Description = "This is the Punch of Art painting description",
                            Price = 5650,
                            ImageURL = "http://commondatastorage.googleapis.com/codeskulptor-assets/gutenberg.jpg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            OrganizerId = 1,
                            FundRaiserId = 3,
                            PaintingCategory = PaintingCategory.Cartoon
                        },
                        new Painting()
                        {
                            Name = "Handloom Art",
                            Description = "This is the Handloom Art painting description",
                            Price = 3950,
                            ImageURL = "http://commondatastorage.googleapis.com/codeskulptor-assets/explosion.hasgraphics.png",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            OrganizerId = 1,
                            FundRaiserId = 5,
                            PaintingCategory = PaintingCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Artists & Paintings
                if (!context.Artists_Paintings.Any())
                {
                    context.Artists_Paintings.AddRange(new List<Artist_Painting>()
                    {
                        new Artist_Painting()
                        {
                            ArtistId = 1,
                            PaintingId = 1
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 3,
                            PaintingId = 1
                        },

                         new Artist_Painting()
                        {
                            ArtistId = 1,
                            PaintingId = 2
                        },
                         new Artist_Painting()
                        {
                            ArtistId = 4,
                            PaintingId = 2
                        },

                        new Artist_Painting()
                        {
                            ArtistId = 1,
                            PaintingId = 3
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 2,
                            PaintingId = 3
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 5,
                            PaintingId = 3
                        },


                        new Artist_Painting()
                        {
                            ArtistId = 2,
                            PaintingId = 4
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 3,
                            PaintingId = 4
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 4,
                            PaintingId = 4
                        },


                        new Artist_Painting()
                        {
                            ArtistId = 2,
                            PaintingId = 5
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 3,
                            PaintingId = 5
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 4,
                            PaintingId = 5
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 5,
                            PaintingId = 5
                        },


                        new Artist_Painting()
                        {
                            ArtistId = 3,
                            PaintingId = 6
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 4,
                            PaintingId = 6
                        },
                        new Artist_Painting()
                        {
                            ArtistId = 5,
                            PaintingId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
