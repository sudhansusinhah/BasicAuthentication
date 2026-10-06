using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.WebPages;

namespace Basic_Authentication.Areas.HelpPage
{
    
    public class BasicAuthentication:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization==null)
            {
                actionContext.Response=actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            else
            {

                string Authenticationcode = actionContext.Request.Headers.Authorization.Parameter;
                string decodestring = Encoding.UTF8.GetString(Convert.FromBase64String(Authenticationcode));
                string[] usernamePassword = decodestring.Split(':');
                string UserName = usernamePassword[0];
                string Password = usernamePassword[1];
              
            }

        }
    }
}