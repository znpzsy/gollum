using System.Net.Http.Headers;
using System.Web.Configuration;
using System.Web.Http;
using gollum.web.api.App_Start;

namespace gollum.web.api
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiConfig
    {
        /// <summary>
        /// Web API Configuration with Attribute Routes
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            #region CORS & Auth0

            config.EnableCors();

            var clientId = WebConfigurationManager.AppSettings["auth0:ClientId"];
            var clientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];


            config.MessageHandlers.Add(new JsonWebTokenValidationHandler()
            {
                Audience = clientId,  // client id
                SymmetricKey = clientSecret   // client secret
            });
            #endregion

            #region JSON

            /// refer : http://stackoverflow.com/questions/9847564/how-do-i-get-asp-net-web-api-to-return-json-instead-of-xml-using-chrome
            /// makes sure you get json on most queries.
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            #endregion


            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
