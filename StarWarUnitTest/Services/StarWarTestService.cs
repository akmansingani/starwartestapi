﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StarWarTestAPI.Models;
using StarWarTestAPI.Services;

namespace StarWarUnitTest.Services
{
    public class StarWarTestService : IStarWarService
    {
        private readonly List<FilmModel> _films;

        private readonly List<Films_CharacterModels> _films_characters;

        private readonly List<PersonModel> _people;

        private readonly List<Films_Species> _films_species;

        private readonly List<SpeciesModel> _species;

        private readonly List<People_Species> _species_people;

        private readonly List<Films_Planet> _films_planets;

        private readonly List<Films_StarShips> _films_starships;

        private readonly List<StarsShips_Pilot> _starships_pilots;

        private readonly List<PlanetModel> _planets;

        public StarWarTestService()
        {
            // films data
            _films = new List<FilmModel>{
                new FilmModel()
                {
                    id = 1,
                    created = DateTime.Now,
                    director = "George Lucas",
                    edited = DateTime.Now,
                    episode_id = 4,
                    opening_crawl = @"It is a period of civil war.
                                        Rebel spaceships, striking
                                        from a hidden base, have won
                                        their first victory against
                                        the evil Galactic Empire.

                                        During the battle, Rebel
                                        spies managed to steal secret
                                        plans to the Empire's
                                        ultimate weapon, the DEATH
                                        STAR, an armored space
                                        station with enough power
                                        to destroy an entire planet.

                                        Pursued by the Empire's
                                        sinister agents, Princess
                                        Leia races home aboard her
                                        starship, custodian of the
                                        stolen plans that can save her
                                        people and restore
                                        freedom to the galaxy....",
                    producer = "Gary Kurtz, Rick McCallum",
                    release_date = DateTime.Now,
                    title = "A New Hope"
                },
                new FilmModel()
                {
                    id = 2,
                    created = DateTime.Now,
                    director = "Irvin Kershner",
                    edited = DateTime.Now,
                    episode_id = 4,
                    opening_crawl = @"It is a dark time for the
                                        Rebellion. Although the Death
                                        Star has been destroyed,
                                        Imperial troops have driven the
                                        Rebel forces from their hidden
                                        base and pursued them across
                                        the galaxy.

                                        Evading the dreaded Imperial
                                        Starfleet, a group of freedom
                                        fighters led by Luke Skywalker
                                        has established a new secret
                                        base on the remote ice world
                                        of Hoth.

                                        The evil lord Darth Vader,
                                        obsessed with finding young
                                        Skywalker, has dispatched
                                        thousands of remote probes into
                                        the far reaches of space....",
                    producer = "Gary Kurtz, Rick McCallum",
                    release_date = DateTime.Now,
                    title = "The Empire Strikes Back"
                }
            };

            // films character data
            _films_characters = new List<Films_CharacterModels>()
            {
                new Films_CharacterModels
                {
                    film_id = 1,
                    people_id = 1
                },
                new Films_CharacterModels
                {
                    film_id = 2,
                    people_id = 2
                },
                new Films_CharacterModels
                {
                    film_id = 3,
                    people_id = 1
                }
            };

            // people data
            _people = new List<PersonModel>()
            {
                new PersonModel
                {
                    id = 1,
                    birth_year = "19BBY",
                    created = DateTime.Now,
                    edited = DateTime.Now,
                    eye_color = "blue",
                    gender = "male",
                    hair_color = "blond",
                    height = "172",
                    homeworld = 1,
                    mass = "1",
                    name = "Luke Skywalker",
                    skin_color = "fair"
                },
                new PersonModel
                {
                    id = 2,
                    birth_year = "112BBY",
                    created = DateTime.Now,
                    edited = DateTime.Now,
                    eye_color = "yellow",
                    gender = "male",
                    hair_color = "blond",
                    height = "172",
                    homeworld = 1,
                    mass = "1",
                    name = "C-3PO",
                    skin_color = "gold"
                }
            };

            // films species data
            _films_species = new List<Films_Species>()
            {
                new Films_Species
                {
                    film_id = 1,
                    species_id = 1
                },
                new Films_Species
                {
                    film_id = 2,
                    species_id = 2
                },
                new Films_Species
                {
                    film_id = 3,
                    species_id = 1
                }
            };

            // species data
            _species = new List<SpeciesModel>()
            {
                new SpeciesModel
                {
                    id = 1,
                    name = "Human",
                },
                new SpeciesModel
                {
                    id = 2,
                    name = "Yoda",
                }
            };

            // species people data
            _species_people = new List<People_Species>()
            {
                new People_Species
                {
                    people_id = 1,
                    species_id = 1
                },
                new People_Species
                {
                    people_id = 2,
                    species_id = 2
                },
                new People_Species
                {
                    people_id = 1,
                    species_id = 2
                }
            };

            // planets data
            _planets = new List<PlanetModel>()
            {
                new PlanetModel
                {
                    id = 1,
                    name = "Tatooine"
                },
                new PlanetModel
                {
                    id = 2,
                    name = "Alderaan"
                },
                new PlanetModel
                {
                    id = 3,
                    name = "Yavin IV"
                }
            };

            // films planets data
            _films_planets = new List<Films_Planet>()
            {
                new Films_Planet
                {
                    planet_id = 1,
                    film_id = 1
                },
                new Films_Planet
                {
                    planet_id = 2,
                    film_id = 2
                },
                new Films_Planet
                {
                    planet_id = 3,
                    film_id = 1
                },
               
            };

            // films starships data
            _films_starships = new List<Films_StarShips>()
            {
                new Films_StarShips
                {
                    starship_id = 1,
                    film_id = 1
                },
                new Films_StarShips
                {
                    starship_id = 2,
                    film_id = 2
                },
                new Films_StarShips
                {
                    starship_id = 1,
                    film_id = 1
                },

            };

            // pilots starships data
            _starships_pilots = new List<StarsShips_Pilot>()
            {
                new StarsShips_Pilot
                {
                    starship_id = 1,
                    people_id = 1
                },
                new StarsShips_Pilot
                {
                    starship_id = 2,
                    people_id = 2
                },
                new StarsShips_Pilot
                {
                    starship_id = 1,
                    people_id = 1
                },

            };
            //  , ,  
        }

        public ResponseHandler getMovieTitleOpeningCrawl()
        {
            try
            {
                // finds movie title with longest opening crawl

                var queryList = _films.AsQueryable();

                var movies = (from f in queryList
                              orderby f.opening_crawl.Max()
                              select f.title).First();

                return new ResponseHandler
                {
                    status = "success",
                    response = movies
                };

            }
            catch (Exception ex)
            {
                return new ResponseHandler
                {
                    status = "error",
                    response = "Please try later!"
                };
            }
        }

        public ResponseHandler getCharacterMostAppeared()
        {
            try
            {
                // finds movie character who appeared most

                var films_characters = _films_characters.AsQueryable();
                var people = _people.AsQueryable();

                var characterName = (from t1 in _films_characters
                                     join t2 in people on t1.people_id equals t2.id
                                     group new { t1, t2 } by new { t1.people_id, t2.name } into t3
                                     orderby t3.Count() descending, t3.FirstOrDefault().t2.name
                                     select t3.FirstOrDefault().t2.name).FirstOrDefault();

                return new ResponseHandler
                {
                    status = "success",
                    response = characterName
                };

            }
            catch (Exception ex)
            {
                return new ResponseHandler
                {
                    status = "error",
                    response = "Please try later!"
                };
            }
        }

        public ResponseHandler getMostNumberOfSpecies()
        {
            try
            {
                var films_species = _films_species.AsQueryable();
                var species = _species.AsQueryable();
                var species_people = _species_people.AsQueryable();

                // get lists of most number of appeared species in movie
                var speciesList = (from t1 in films_species
                                   join t2 in species on t1.species_id equals t2.id
                                   group new { t1, t2 } by new { t1.species_id, t2.name } into t3
                                   orderby t3.Count() descending, t3.FirstOrDefault().t1.species_id
                                   select new
                                   {
                                       speciesname = t3.FirstOrDefault().t2.name,
                                       speciescount = (from t4 in species_people
                                                       where t4.species_id == t3.FirstOrDefault().t1.species_id
                                                       select t4).Count()
                                   });

                return new ResponseHandler
                {
                    status = "success",
                    response = JsonConvert.SerializeObject(new
                    {
                        species = speciesList,
                    })
                };

            }
            catch (Exception ex)
            {
                return new ResponseHandler
                {
                    status = "error",
                    response = "Please try later!"
                };
            }
        }

        public ResponseHandler getPlanetNumberOfPilots()
        {
            try
            {
                // get list of planets with relation to film and starship
                var planetlist = (from t1 in _films_planets
                                  join t2 in _films_starships on t1.film_id equals t2.film_id
                                  select new
                                  {
                                      planetid = t1.planet_id,
                                      filmid = t1.film_id,
                                      starshipid = t2.starship_id
                                  }).GroupBy(x => x.planetid);

                // get list of people data base on planet list
                var peopleData = (from t1 in planetlist
                                 select new
                                 {
                                     planetid = t1.Key,
                                     people = (from t in _starships_pilots
                                               where t1.Select(g => g.starshipid).Contains(t.starship_id)
                                               select new { id = t.people_id }
                                                ).Distinct()
                                 });

                // get final data with people count, species name, people name,planet name
                var taskData = (from t1 in peopleData
                                join t2 in _planets on t1.planetid equals t2.id
                                select new
                                {
                                    planet_id = t1.planetid,
                                    planetname = t2.name,
                                    people_count = t1.people.Count(),
                                    people_list = (from z1 in _people
                                                   join z2 in _species_people on z1.id equals z2.people_id
                                                   join z3 in _species on z2.species_id equals z3.id
                                                   join z4 in t1.people on z1.id equals z4.id
                                                   where t1.people.Select(g => g.id).Contains(z1.id)
                                                   select new
                                                   {
                                                       people_name = z1.name + " - " + z3.name
                                                   })
                                }).OrderByDescending(x => x.people_count).Take(5);

                return new ResponseHandler
                {
                    status = "success",
                    response = JsonConvert.SerializeObject(new
                    {
                        planets = taskData,
                    })
                };

            }
            catch (Exception ex)
            {
                return new ResponseHandler
                {
                    status = "error",
                    response = "Please try later!"
                };
            }
        }
    }
}
