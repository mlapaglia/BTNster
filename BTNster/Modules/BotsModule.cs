using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Modules
{
    public class BotsModule : NancyModule
    {
        public BotsModule(IRCBots.Bot ircBot)
        {
            Get["/Bots"] = parameters =>
            {
                return View["Index"];
            };

            Get["/Bots/Connect"] = parameters =>
            {
                ircBot.Connect();
                return true;
            };
        }
    }
}
