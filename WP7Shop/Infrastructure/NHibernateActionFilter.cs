using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WP7Shop.Controllers;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Automapping;
using WP7Shop.Models.Entities;
using NHibernate.Tool.hbm2ddl;

namespace WP7Shop.Infrastructure
{
    public class NHibernateActionFilter : ActionFilterAttribute
    {
        private static readonly ISessionFactory sessionFactory = BuildSessionFactory();

        private static ISessionFactory BuildSessionFactory()
        {
            var config = new NhibConfig();

            var databaseConfig = MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c.
                    FromConnectionStringWithKey("WP7ShopDB"));

            var sessionFactory = Fluently.Configure()
                .Database(databaseConfig)
                .Mappings(m =>
                    m.AutoMappings
                    .Add(AutoMap.AssemblyOf<Entity>(config)
                    .IgnoreBase<Entity>()))
                    .ExposeConfiguration(cfg =>
                        {
                        //Uncomment to drop/create DB
                            new SchemaExport(cfg)
                            .Create(false, true);
                        })
                        .BuildSessionFactory();

            return sessionFactory;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionController = filterContext.Controller as SessionController;

            if (sessionController == null)
                return;

            sessionController.Session = sessionFactory.OpenSession();
            sessionController.Session.BeginTransaction();

            //TODO: Have it get the current session user id
            //sessionController.Session.EnableFilter("CurrentUser")
            //    .SetParameter("userId", 1);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var sessionController = filterContext.Controller as SessionController;

            if (sessionController == null)
                return;

            using (var session = sessionController.Session)
            {
                if (session == null)
                    return;
                if (!session.Transaction.IsActive)
                    return;
                if (filterContext.Exception != null)
                    session.Transaction.Rollback();
                else
                    session.Transaction.Commit();
            }

        }
    }
}