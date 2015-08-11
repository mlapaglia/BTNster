using BTNster.IRC;
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
        public BotsModule(Bot ircBot)
        {
            Get["/Bots"] = parameters =>
            {
                return View["Index"];
            };

            Get["/Bots/Connect"] = parameters =>
            {
                string site = "irc.what-network.org";
                int port = 6697;
                bool useSSL = true;
                ircBot.Connect(site, port, useSSL);

                return true;
            };
        }
    }
}
