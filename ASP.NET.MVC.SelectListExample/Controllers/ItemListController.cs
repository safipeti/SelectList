using ASP.NET.MVC.SelectListExample.Models;
using ASP.NET.MVC.SelectListsExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.MVC.SelectListExample.Controllers
{
    public class ItemListController : Controller
    {
        public ActionResult Index()
        {
            // Get all the animals and continents that we want pass to the selectlist
            // and assign them to the corresponding properties
            var animals = Help.GetAnimals();
            var continents = Help.GetContinents();

            // Construct the view model that we want to pass to the view
            var viewModel = new ItemListModelViewModel
            {
                PageTitle = "Using ViewModel property as a collection of items",

                // Just pass a list of objects to the view
                // The view's Razor helper will call the constructor method of the SelectList 
                // and create a the selectlist from the passed parameters.
                AnimalList = animals,
                ContinentList = continents,

                OptionLabel = "-- Select a continent, please! --",

                // It can be null (default value), so no animals will be preselected. 
                // If you assign a value, animals with the ID of those numbers will be preselected
                SelectedAnimalsIDs = new int[] { 2, 5, 8 },

                // It can be 0 (default value), so no continent will be preselected
                // If you assign a value, continent with that ID will be preselected
                SelectedContinentID = 4,

                // Names of the continent and animals before submission.
                // If using default value (null), check for null in the view
                ContinentName = string.Empty,
                AnimalNames = new List<string>()
            };

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Index(ItemListModelViewModel m)
        {
            // REPOPULATE THE SELECT LIST:

            // Get all the animals and continents that we want pass to the selectlist
            // and assign them to the corresponding properties
            var animals = Help.GetAnimals();
            var continents = Help.GetContinents();

            // Re-populate animal and continent lists:
            m.ContinentList = continents;
            m.AnimalList = animals;

            // get the names of selected continent and animals
            m.ContinentName = continents.Where(c => c.ContinentID == m.SelectedContinentID).FirstOrDefault().Name;
            m.AnimalNames = new List<string>();

            foreach (var a in animals)
            {
                if (m.SelectedAnimalsIDs.Contains(a.AnimalID))
                {
                    m.AnimalNames.Add(a.Name);
                }
            }

            return View(m);
        }
    }
}
