using ASP.NET.MVC.SelectListsExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.MVC.SelectListExample.Models
{
    /// <summary>
    /// Helper class which has two static methods. Both
    /// methods mimic data resource
    /// </summary>
    public static class Help
    {
        /// <summary>
        /// This method returns a collection of Animal objects.
        /// These animals will populate the listbox.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Animal> GetAnimals()
        {
            return new List<Animal>
            {
                new Animal { AnimalID = 1, Name = "Gorilla" },
                new Animal { AnimalID = 2, Name = "Tiger" },
                new Animal { AnimalID = 3, Name = "Python" },
                new Animal { AnimalID = 4, Name = "Elephant" },
                new Animal { AnimalID = 5, Name = "Jaguar" },
                new Animal { AnimalID = 6, Name = "Lion" },
                new Animal { AnimalID = 7, Name = "Crocodile" },
                new Animal { AnimalID = 8, Name = "Bear" }
            };
        }

        /// <summary>
        /// This method returns a collection of Continent objects.
        /// These continents will populate the dropdown list.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Continent> GetContinents()
        {
            return new List<Continent>
            {
                new Continent { ContinentID = 1, Name="Africa" } ,
                new Continent { ContinentID = 2, Name="America" } ,
                new Continent { ContinentID = 3, Name="Asia" } ,
                new Continent { ContinentID = 4, Name="Australia" } ,
                new Continent { ContinentID = 5, Name="Antartic" } ,
                new Continent { ContinentID = 6, Name="Europe" } ,
            };
        }
    }
}