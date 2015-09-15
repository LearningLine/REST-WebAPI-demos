using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Mod06.Api
{
    [Authorize]
    public class UserController: ApiController
    {
        public string Get()
        {
            if (User.Identity.IsAuthenticated)
            {
                return "The user is authenticated as: " + User.Identity.Name;
            }

            return "The user is not authenticated";
        }
    }
}