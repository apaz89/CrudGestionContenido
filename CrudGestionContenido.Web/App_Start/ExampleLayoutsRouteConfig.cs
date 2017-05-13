using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using NavigationRoutes;
using CrudGestionContenido.Web.Controllers;

namespace BootstrapMvcSample
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapNavigationRoute<HomeController>("Automatic Scaffolding", c => c.Index());

            routes.MapNavigationRoute<ExampleLayoutsController>("Configuracion", c => c.Starter())
                  .AddChildRoute<DepartamentosController>("Departamentos", c => c.Index())
                  .AddChildRoute<EmpleadosController>("Empleados", c => c.Index())
                //.AddChildRoute<ExampleLayoutsController>("Sign In", c => c.SignIn())
                ;
        }
    }
}
