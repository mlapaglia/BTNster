using BTNster.IRC;
using BTNster.Web.Models;
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
        public BotsModule(IRC.Bot ircBot)
        {
            Get["/Bots"] = parameters =>
            {
                BotsModel model = new BotsModel();

                model.Bots.Add(new Web.Models.Bot()
                {
                    BotID = 1,
                    Errors = 0,
                    IsConnected = true,
                    IsConnecting = false,
                    SiteName = "BTN",
                });

                return View["Index", model];
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
