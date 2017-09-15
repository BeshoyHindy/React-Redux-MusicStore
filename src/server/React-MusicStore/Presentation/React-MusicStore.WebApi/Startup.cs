using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using ReactMusicStore.Core.IoC;
using ReactMusicStore.WebApi.Framework.Mapping;

[assembly: OwinStartup(typeof(ReactMusicStore.WebApi.Startup))]
namespace ReactMusicStore.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var mappingDefinitions = new MappingDefinitions();
            mappingDefinitions.Initialise();



            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            WebApiConfig.Register(config);

            new InversionOfControl().Initialise(config);

            app.UseWebApi(config);
        }
    }
}
