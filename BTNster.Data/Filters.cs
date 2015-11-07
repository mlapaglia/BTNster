using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Data
{
    public static class Filters
    {
        public static List<BTNster.Models.Filter> GetFilters(int FilterID)
        {
            using (BTNsterEntities db = new BTNsterEntities())
            {
                List<Filter> filters = db.Filter.Where(x => x.FilterID == FilterID).ToList();

                List<BTNster.Models.Filter> filterList = new List<Models.Filter>();

                foreach (Filter filter in filters)
                {
                    BTNster.Models.Filter newFilter = new Models.Filter()
                    {
                        DownloadBetterReleases = filter.DownloadBetterReleases,
                        EndDate = filter.EndDate,
                        FilterName = filter.FilterTitle,
                        RememberHistory = filter.RememberHistory,
                        SceneNo = filter.SceneNo,
                        SceneYes = filter.SceneYes,
                        StartDate = filter.StartDate,
                    };

                    filterList.Add(newFilter);
                }

                return filterList;
            }
        }
    }
}
