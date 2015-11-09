using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Models
{
    public class Filter
    {
        public String FilterName { get; set; }

        public List<String> Containers { get; set; }

        public List<String> Sources { get; set; }

        public List<String> Resolutions { get; set; }

        public List<String> Codecs { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Boolean? RememberHistory { get; set; }

        public Boolean? DownloadBetterReleases { get; set; }

        public Boolean? SceneYes { get; set; }

        public Boolean? SceneNo { get; set; }
    }

    public class Series
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public int Season { get; set; }

        public int Episode { get; set; }
    }
}
