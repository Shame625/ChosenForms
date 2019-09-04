using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChosenForms.Services
{
    public class DropdownService
    {
        public List<SelectListItem> GetOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "Option 1", Value = "1"},
                new SelectListItem {Text = "Option 2", Value = "2"},
                new SelectListItem {Text = "Option 3", Value = "3"}
            };
        }
    }
}
