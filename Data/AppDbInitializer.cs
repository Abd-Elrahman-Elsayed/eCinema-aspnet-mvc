using eCinema.Models;

namespace eCinema.Data
{
    public static class AppDbInitializer
    {
        public static WebApplication Seed(this WebApplication applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                try
                {
                    context.Database.EnsureCreated();
                    //Cinemas
                    if (!context.Cinemas.Any())
                    {
                        context.Cinemas.AddRange(new HashSet<Cinema>()
                    {
                        new Cinema
                        {
                            Name = "Cinema 1",
                            Description = "This is the best cinema",
                            Logo = "https://img.freepik.com/premium-vector/cinema-logo_23-2147503279.jpg"
                        },
                        new Cinema
                        {
                            Name = "Cinema 2",
                            Description = "This is the best cinema",
                            Logo = "https://img.freepik.com/premium-vector/cinema-logo_23-2147503279.jpg"
                        },new Cinema
                        {
                            Name = "Cinema 3",
                            Description = "This is the third best cinema",
                            Logo = "https://img.freepik.com/premium-vector/cinema-logo_23-2147503279.jpg"
                        },new Cinema
                        {
                            Name = "Cinema 4",
                            Description = "This is the forth best cinema",
                            Logo = "https://img.freepik.com/premium-vector/cinema-logo_23-2147503279.jpg"
                        },new Cinema
                        {
                            Name = "Cinema 5",
                            Description = "This is the fifth best cinema",
                            Logo = "https://img.freepik.com/premium-vector/cinema-logo_23-2147503279.jpg"
                        },
                    });
                        context.SaveChanges();
                    }

                    //Actors
                    if (!context.Actors.Any())
                    {
                        context.Actors.AddRange(new HashSet<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Amir Dwidar",
                            Bio = "This is the best actor",
                            ImageUrl = "https://siachenstudios.com/wp-content/uploads/2022/03/robert-1024x1024.jpg",
                        },
                        new Actor()
                        {
                            FullName = "Dalia Akram",
                            Bio = "This is the second best actor",
                            ImageUrl = "https://siachenstudios.com/wp-content/uploads/2022/03/robert-1024x1024.jpg",
                        },new Actor()
                        {
                            FullName = "Mohsen Metwally",
                            Bio = "This is the third best actor",
                            ImageUrl = "https://siachenstudios.com/wp-content/uploads/2022/03/robert-1024x1024.jpg",
                        },new Actor()
                        {
                            FullName = "Zaki Chan",
                            Bio = "This is the forth best actor",
                            ImageUrl = "https://siachenstudios.com/wp-content/uploads/2022/03/robert-1024x1024.jpg",
                        },new Actor()
                        {
                            FullName = "Mona Walid",
                            Bio = "This is the fifth best actor",
                            ImageUrl = "https://siachenstudios.com/wp-content/uploads/2022/03/robert-1024x1024.jpg",
                        }
                    });
                        context.SaveChanges();
                    }

                    //Producers
                    if (!context.Producers.Any())

                    {
                        context.Producers.AddRange(new HashSet<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Fady Saad",
                            Bio = "This is the best Producer",
                            ImageUrl = "https://assets-in.bmscdn.com/iedb/artist/images/website/poster/large/ridley-scott-1878-13-09-2017-02-23-16.jpg",
                        },
                        new Producer()
                        {
                            FullName = "Emad Safwat",
                            Bio = "This is the second best Producer",
                            ImageUrl = "https://assets-in.bmscdn.com/iedb/artist/images/website/poster/large/ridley-scott-1878-13-09-2017-02-23-16.jpg",
                        },new Producer()
                        {
                            FullName = "Ashraf Zaki",
                            Bio = "This is the third best Producer",
                            ImageUrl = "https://assets-in.bmscdn.com/iedb/artist/images/website/poster/large/ridley-scott-1878-13-09-2017-02-23-16.jpg",
                        },new Producer()
                        {
                            FullName = "Reham Rami",
                            Bio = "This is the forth best Producer",
                            ImageUrl = "https://assets-in.bmscdn.com/iedb/artist/images/website/poster/large/ridley-scott-1878-13-09-2017-02-23-16.jpg",
                        },new Producer()
                        {
                            FullName = "Nadia Saleh",
                            Bio = "This is the fifth best Producer",
                            ImageUrl = "https://assets-in.bmscdn.com/iedb/artist/images/website/poster/large/ridley-scott-1878-13-09-2017-02-23-16.jpg",
                        }
                    });
                        context.SaveChanges();
                    }

                    //Movies
                    if (!context.Movies.Any())
                    {
                        context.Movies.AddRange(new HashSet<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Triple X",
                            Description = "This is the best Movie",
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0969/9128/products/1917_-_Sam_Mendes_-_Hollywood_War_Film_Classic_English_Movie_Poster_9ef86295-4756-4c71-bb4e-20745c5fbc1a.jpg?v=1582781084",
                            Price = 320,
                            StartDate = DateTime.Now.AddDays(5),
                            EndtDate = DateTime.Now.AddDays(30),
                            MovieCategory = Enum.MovieCategory.Action,
                            ProducerId = 1,
                            CinemaId= 1,
                        },
                        new Movie()
                        {
                            Name = "Bundle X",
                            Description = "This is the second best Movie",
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0969/9128/products/1917_-_Sam_Mendes_-_Hollywood_War_Film_Classic_English_Movie_Poster_9ef86295-4756-4c71-bb4e-20745c5fbc1a.jpg?v=1582781084",
                            Price = 220,
                            StartDate = DateTime.Now.AddDays(-5),
                            EndtDate = DateTime.Now.AddDays(30),
                            MovieCategory = Enum.MovieCategory.Comedy,
                            ProducerId = 2,
                            CinemaId= 2,
                        },new Movie()
                        {
                            Name = "Vertana X",
                            Description = "This is the third best Movie",
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0969/9128/products/1917_-_Sam_Mendes_-_Hollywood_War_Film_Classic_English_Movie_Poster_9ef86295-4756-4c71-bb4e-20745c5fbc1a.jpg?v=1582781084",
                            Price = 180,
                            StartDate = DateTime.Now.AddDays(3),
                            EndtDate = DateTime.Now.AddDays(10),
                            MovieCategory = Enum.MovieCategory.Drama,
                            ProducerId = 3,
                            CinemaId= 3,
                        },new Movie()
                        {
                            Name = "Diana X",
                            Description = "This is the forth best Movie",
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0969/9128/products/1917_-_Sam_Mendes_-_Hollywood_War_Film_Classic_English_Movie_Poster_9ef86295-4756-4c71-bb4e-20745c5fbc1a.jpg?v=1582781084",
                            Price = 380,
                            StartDate = DateTime.Now.AddDays(1),
                            EndtDate = DateTime.Now.AddDays(12),
                            MovieCategory = Enum.MovieCategory.Documentry,
                            ProducerId = 4,
                            CinemaId= 4,
                        },new Movie()
                        {
                            Name = "Raniera X",
                            Description = "This is the fifth best Movie",
                            ImageUrl = "https://cdn.shopify.com/s/files/1/0969/9128/products/1917_-_Sam_Mendes_-_Hollywood_War_Film_Classic_English_Movie_Poster_9ef86295-4756-4c71-bb4e-20745c5fbc1a.jpg?v=1582781084",
                            Price = 410,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndtDate = DateTime.Now.AddDays(-2),
                            MovieCategory = Enum.MovieCategory.Action,
                            ProducerId = 5,
                            CinemaId= 5,
                        }
                    });
                        context.SaveChanges();
                    }

                    //Actor_Movies
                    if (!context.Actor_Movies.Any())
                    {
                        context.Actor_Movies.AddRange(new HashSet<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        },new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 3
                        },new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },
                    });
                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return applicationBuilder;
            }
        }
    }
}

