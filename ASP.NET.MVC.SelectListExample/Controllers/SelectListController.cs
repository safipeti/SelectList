using ASP.NET.MVC.SelectListExample.Models;
using ASP.NET.MVC.SelectListsExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.MVC.SelectListExample.Controllers
{
    public class SelectListController : Controller
    {
        public ActionResult Index()
        {
            // Get all the animals and continents that we want pass to the selectlist
            // and assign them to the corresponding properties
            var animals = Help.GetAnimals();
            var continents = Help.GetContinents();

            // Construct the view model that we want to pass to the view
            var viewModel = new SelectListViewModel
            {
                PageTitle = "Using ViewModel property as SelectList type",

                // The view's Razor helper methods will receive a constructed
                // SelectList object
                AnimalList = new SelectList(animals, "AnimalID", "Name"),
                ContinentList = new SelectList(continents, "ContinentID", "Name"),

                OptionLabel = "--- Select a continent! --- ",

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
        public ActionResult Index(SelectListViewModel m)
        {
            // REPOPULATE THE SELECT LIST:

            // Get all the animals and continents that we want pass to the selectlist
            // and assign them to the corresponding properties
            var animals = Help.GetAnimals();
            var continents = Help.GetContinents();

            // Re-populate animal and continent SelectLists:
            m.AnimalList = new SelectList(animals, "AnimalID", "Name", m.SelectedAnimalsIDs);
            m.ContinentList = new SelectList(continents, "ContinentID", "Name", m.SelectedContinentID);

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
