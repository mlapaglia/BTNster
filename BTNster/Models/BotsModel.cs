using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Web.Models
{
    public class BotsModel
    {
        public int TotalBots
        {
            get
            {
                return Bots.Count();
            }
        }

        public int ActiveBots
        {
            get
            {
                return Bots.Where(x => x.IsConnected).Count();
            }
        }

        public int BotsWithErrors
        {
            get
            {
                return Bots.Where(x => x.Errors > 0).Count();
            }
        }

        public int BotsConnecting
        {
            get
            {
                return Bots.Where(x => x.IsConnecting).Count();
            }
        }

        public List<Bot> Bots { get; set; }

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
