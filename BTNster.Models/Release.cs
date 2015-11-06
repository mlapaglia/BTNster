using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Models
{
    public abstract class Release
    {
        /// <summary>
        /// Unique ID of the release
        /// </summary>
        public long ReleaseID { get; set; }

        /// <summary>
        /// The raw announce string captured by the IRC bot
        /// </summary>
        public string RawIRCAnnounce { get; set; }

        /// <summary>
        /// The date the IRC announce was seen by the IRC bot
        /// </summary>
        public DateTime RawIRCAnnounceDate { get; set; }
    }

    public class BTNRelease : Release
    {
        /// <summary>
        /// The official date of the release, not related to the date the announce was seen
        /// in IRC
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        public string Title { get; set; }

        public string Series { get; set; }

        public int SeasonNumber { get; set; }
        
        public int EpisodeNumber { get; set; }
    }
}
