using BTNster.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Models
{
    public class EditFilterModel
    {
        public Filter Filter { get; set; }

        public string FilterName { get; set; }

        public List<string> Sources { get; set; }

        public List<string> Containers { get; set; }

        public List<string> Resolutions { get; set; }

        public List<string> Codecs { get; set; }

        public List<Series> Series { get; set; }

        public EditFilterModel()
        {
            FilterName = "Test Filter";

            Sources = new List<string>();
            Sources.Add("HDTV");
            Sources.Add("PDTV");
            Sources.Add("DSR");
            Sources.Add("DVDRip");
            Sources.Add("TVRip");
            Sources.Add("VHSRip");
            Sources.Add("Bluray");
            Sources.Add("BDRip");
            Sources.Add("BRRip");
            Sources.Add("DVD5");
            Sources.Add("DVD9");
            Sources.Add("HDDVD");
            Sources.Add("WEB-DL");
            Sources.Add("WEBRip");
            Sources.Add("BD5");
            Sources.Add("BD9");
            Sources.Add("BD25");
            Sources.Add("BD50");
            Sources.Add("Mixed");
            Sources.Add("Unknown");

            Containers = new List<string>();
            Containers.Add("AVI");
            Containers.Add("MKV");
            Containers.Add("VOB");
            Containers.Add("MPEG");
            Containers.Add("MP4");
            Containers.Add("ISO");
            Containers.Add("WMV");
            Containers.Add("TS");
            Containers.Add("M4V");
            Containers.Add("M2TS");

            Resolutions = new List<string>();
            Resolutions.Add("SD");
            Resolutions.Add("720p");
            Resolutions.Add("1080p");
            Resolutions.Add("1080i");
            Resolutions.Add("Portable Device");

            Codecs = new List<string>();
            Codecs.Add("XViD");
            Codecs.Add("x264");
            Codecs.Add("MPEG2");
            Codecs.Add("DiVX");
            Codecs.Add("DVDR");
            Codecs.Add("VC-1");
            Codecs.Add("h.264");
            Codecs.Add("WMV");
            Codecs.Add("BD");
            Codecs.Add("x264-Hi10P");

            Series = new List<Series>();
            Series.Add(new Series()
            {
                Episode = 0,
                Season = 7,
                SeriesName = "Archer",
                Title = string.Empty
            });
        }
    }

    public class Series
    {
        public string SeriesName { get; set; }
        public string Title { get; set; }
        public short Season { get; set; }
        public short Episode { get; set; }

    }
}
