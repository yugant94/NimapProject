using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
//using NimapProject.; // Import your service classes
using NimapProject.Models;   // Import your models

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // Register services
        container.RegisterType<ICategoryService, CategoryService>();
        container.RegisterType<IProductService, ProductService>();

        // Set the dependency resolver
        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
}
