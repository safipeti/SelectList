using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.MVC.SelectListsExample.Models
{

    public class BaseViewModel
    {
        // This property holds the page's title, set in the controller
        public string PageTitle { get; set; }

        // This property will be populated with te selected animals' ID when user posts the form 
        public int[] SelectedAnimalsIDs { get; set; }

        // This property will be populated with the selected continent's ID when user posts the form
        public int SelectedContinentID { get; set; }

        // After form submission, this property will hold the selected continent's name
        public string ContinentName { get; set; }

        // After form submission, this property will hold the name of the animals
        public List<string> AnimalNames { get; set; }

        // Option Label for DropDownList
        public string OptionLabel { get; set; }
    }


    /// <summary>
    /// IItemListViewModel: name indicates that select list items are collected as IEnumerable lists
    /// </summary>
    public class ItemListModelViewModel : BaseViewModel
    {
        // All the animals which will be in the list
        public IEnumerable<Animal> AnimalList { get; set; }

        // All the continents which will be in the list
        public IEnumerable<Continent> ContinentList { get; set; }
    }

    /// <summary>
    /// SelectListViewModel: name indicates that select list items are collected as list of SelectListItem type
    /// </summary>
    public class SelectListViewModel : BaseViewModel
    {
        // This will hold a constructed selectlist with animal items
        public SelectList AnimalList { get; set; }

        // This will hold a constructed selectlist with continent items
        public SelectList ContinentList { get; set; }
    }

    public class SelectListItemViewModel : BaseViewModel
    {
        // All the animals which will be in the list
        public IEnumerable<SelectListItem> AnimalList { get; set; }

        // All the continents which will be in the list
        public IEnumerable<SelectListItem> ContinentList { get; set; }

    }

    
}