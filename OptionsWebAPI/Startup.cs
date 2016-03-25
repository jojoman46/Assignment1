using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Configuration;
using System.Web.Cors;
using System.Threading;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(OptionsWebAPI.Startup))]

namespace OptionsWebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
