using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTNster.Modules
{
    public class StatusModule : NancyModule
    {
        public StatusModule()
        {
            Get["/Status"] = parameters =>
            {
                return View["Index"];
            };
        }
    }
}
