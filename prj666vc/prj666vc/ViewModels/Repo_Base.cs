using prj666vc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj666vc.ViewModels
{
    public class Repo_Base
    {
        protected DataContext ds;

        // Initialize
        public Repo_Base()
        {
            ds = new DataContext();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }
    }
}