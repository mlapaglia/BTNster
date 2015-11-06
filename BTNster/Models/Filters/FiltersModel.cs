using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Web.Models.Filters
{
    public class FiltersModel
    {
        public int TotalFilters
        {
            get
            {
                return Filters.Count();
            }
        }

        public int ActiveFilters
        {
            get
            {
                return Filters.Where(x => x.Active).Count();
            }
        }

        public int FilterMatchesHour
        {
            get
            {
                return Filters.Sum(x => x.MatchesLastHour);
            }
        }

        public int FilterMatchesDay
        {
            get
            {
                return Filters.Sum(x => x.MatchesLastHour);
            }
        }

        public List<Filter> Filters { get; set; }

        public FiltersModel()
        {
            Filters = new List<Filter>();
        }
    }

    public class Filter
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public bool RememberHistory { get; set; }

        public bool DownloadBetterReleases { get; set; }

        public bool SceneYes { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool SceneNo { get; set; }

        public bool Active { get; set; }

        public int MatchesLastHour { get; set; }

        public int MatchesLastDay { get; set; }

        public int Downloads { get; set; }

        public int Errors { get; set; }

        public List<string> Containers { get; set; }

        public List<string> Sources { get; set; }

        public List<string> Resolutions { get; set; }

        public List<string> Codecs { get; set; }

        public Filter(int id, string name, bool active, int matchesLastHour, int matchesLastDay, int downloads, int errors)
        {
            ID = id;
            Name = name;
            Active = active;
            MatchesLastHour = matchesLastHour;
            MatchesLastDay = matchesLastDay;
            Downloads = downloads;
            Errors = errors;
            Containers = new List<string>();
            Resolutions = new List<string>();
            Codecs = new List<string>();
            Sources = new List<string>();
        }
    }
}
