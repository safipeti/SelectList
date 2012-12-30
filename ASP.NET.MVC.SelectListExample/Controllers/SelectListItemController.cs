using ASP.NET.MVC.SelectListExample.Models;
using ASP.NET.MVC.SelectListsExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.MVC.SelectListExample.Controllers
{
    public class SelectListItemController : Controller
    {
        public ActionResult Index()
        {
            // Get all the animals and continents that we want pass to the selectlist
            // and assign them to the corresponding properties
            var animals = Help.GetAnimals();
            var continents = Help.GetContinents();

            // Preselected items
            var selectedAnimalIDs = new int[] { 2, 5, 8 };
            var selectedContinentID = 4;

            // Construct the SelectListItem objects
            var continentList = continents.Select(c => new SelectListItem { Value = c.ContinentID.ToString(), Text = c.Name, Selected = c.ContinentID == selectedContinentID ? true : false }).ToList();
            var animalList = animals.Select(a => new SelectListItem { Value = a.AnimalID.ToString(), Text = a.Name, Selected = selectedAnimalIDs.Contains(a.AnimalID) });

            // Construct the view model that we want to pass to the view
            var viewModel = new SelectListItemViewModel
            {
                PageTitle = "Using a collection of SelectListItems as view model property",

                // The view's Razor helper will receive a collection of SelectListItem object. 
                // The value of properties of each select list item object are set 
                AnimalList = animalList,
                ContinentList = continentList,

                OptionLabel = "*** Please select a continent! ***",

                // It can be null (default value), so no animals will be preselected. 
                // If you assign a value, animals with the ID of those numbers will be preselected
                SelectedAnimalsIDs = selectedAnimalIDs,

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
        public ActionResult Index(SelectListItemViewModel m)
        {
            // Get all the animals and continents that we want pass to the selectlist
            // and assign them to the corresponding properties
            var animals = Help.GetAnimals();
            var continents = Help.GetContinents();

            // Construct the SelectListItem objects
            var continentList = continents.Select(c => new SelectListItem { Value = c.ContinentID.ToString(), Text = c.Name, Selected = m.SelectedContinentID == c.ContinentID }).ToList();
            var animalList = animals.Select(a => new SelectListItem { Value = a.AnimalID.ToString(), Text = a.Name, Selected = m.SelectedAnimalsIDs.Contains(a.AnimalID) });

            // Re-populate animal and continent lists:
            m.ContinentList = continentList;
            m.AnimalList = animalList;

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
