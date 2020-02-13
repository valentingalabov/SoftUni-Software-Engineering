
using IRunesApp.Services;
using IRunesApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP;
using SIS.HTTP.Logging;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;

namespace IRunesApp
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IAlbumsService, AlbumsService>();
            serviceCollection.Add<ITracksService, TracksService>();
        }

        public void Configure(IList<Route> routeTable)
        {
           var db = new ApplicationDbContext();
           db.Database.Migrate();
        }
    }
}
