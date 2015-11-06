using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTNster.Models;
using BTNster.Web.Models.Filters;

namespace BTNster.Modules
{
    public class FiltersModule : NancyModule
    {
        public FiltersModule()
        {
            Get["/Filters"] = parameters =>
            {
                FiltersModel model = new FiltersModel();
                model.Filters.Add(new Filter(1, "test filter 1", true, 1, 1, 1, 0));
                model.Filters.Add(new Filter(2, "filter 2", true, 1, 5, 1, 1));
                model.Filters.Add(new Filter(2, "filter 3", false, 1, 5, 1, 1));
                model.Filters.Add(new Filter(2, "filter 4", true, 1, 5, 1, 1));
                model.Filters.Add(new Filter(2, "filter 5", false, 1, 5, 1, 1));

                return View["Index", model];
            };

            Get["/Filters/Edit"] = parameters =>
            {
                EditFilterModel model = new EditFilterModel();

                Filter filter = new Filter(1, "filter 1", true, 0, 0, 0, 0);
                filter.Codecs.Add("XViD");
                model.Filter = filter;

                return View["EditFilter", model];
            };

            Post["/Filters/Delete"] = parameters =>
            {
                return true;
            };
        }
    }
}
