using System;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using NimapProject.Models;

public static class UnityConfig
{
    public static void RegisterComponents()
    {
        var container = new UnityContainer();
        container.RegisterType<ICategoryService, CategoryService>();
        container.RegisterType<IProductService, ProductService>();
        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }
}
