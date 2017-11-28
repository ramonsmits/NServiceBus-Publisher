using NServiceBus;
using System;
using System.Web.Services;
using Messages;

namespace Publisher
{
    /// <summary>
    /// Summary description for PublisherService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PublisherService : System.Web.Services.WebService
    {
        [WebMethod]
        public string MyService(string message)
        {
            try
            {
                Global.MessageSession.Publish(new RowMessage
                {
                    Message = message
                }).GetAwaiter().GetResult();
                return "Message published to bus";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
