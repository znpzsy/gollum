using System.Net.Http.Headers;
using System.Web.Http;

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
