using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WP7Shop.Infrastructure;
using NHibernate;

namespace WP7Shop.Controllers
{

    public class SessionController : Controller
    {
        public HttpSessionStateBase HttpSession
        {
            get { return base.Session; }
        }

        public new ISession Session { get; set; }
    }
}
