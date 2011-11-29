using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Automapping;

namespace WP7Shop.Infrastructure
{
    public class NhibConfig : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "WP7Shop.Models.Entities";
        }
    }
}