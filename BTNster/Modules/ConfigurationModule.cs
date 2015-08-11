using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Modules
{
    public class ConfigurationModule : NancyModule
    {
        public ConfigurationModule()
        {
            Get["/Configuration"] = parameters =>
            {
                return View["Index"];
            };
        }
    }
}
