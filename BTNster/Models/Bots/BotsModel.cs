using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Web.Models.Bots
{
    public class BotsModel
    {
        /// <summary>
        /// The total amount of bots configured in the system
        /// </summary>
        public int TotalBots
        {
            get
            {
                return Bots.Count();
            }
        }

        /// <summary>
        /// The number of bots currently connected to their network
        /// </summary>
        public int ActiveBots
        {
            get
            {
                return Bots.Where(x => x.IsConnected).Count();
            }
        }

        /// <summary>
        /// The number of bots currently experiencing uncleared errors
        /// </summary>
        public int BotsWithErrors
        {
            get
            {
                return Bots.Where(x => x.Errors > 0).Count();
            }
        }

        /// <summary>
        /// The number of bots currently in the connecting phase
        /// </summary>
        public int BotsConnecting
        {
            get
            {
                return Bots.Where(x => x.IsConnecting).Count();
            }
        }

        /// <summary>
        /// The list of Bots currently configured in the system, used on the UI
        /// </summary>
        public List<Bot> Bots { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BotsModel()
        {
            Bots = new List<Bot>();
        }
    }

    public class Bot
    {
        public long BotID { get; set; }

        public string SiteName { get; set; }

        public bool IsConnected { get; set; }

        public bool IsConnecting { get; set; }

        public int Errors { get; set; }

    }
}
