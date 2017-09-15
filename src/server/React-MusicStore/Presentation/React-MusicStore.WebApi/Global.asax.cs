using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json.Serialization;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Data.Context.Interfaces;
using ReactMusicStore.WebApi.AutoMapper;

namespace ReactMusicStore.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

        }
        protected void Application_EndRequest()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<DbMusicStoreContext>>() as ContextManager<DbMusicStoreContext>;
            if (contextManager != null)
            {
                contextManager.GetContext().Dispose();
            }
        }

    }
}
