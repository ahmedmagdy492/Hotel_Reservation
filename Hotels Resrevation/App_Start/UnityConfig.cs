using Hotels_Resrevation.Controllers;
using Hotels_Resrevation.Models;
using Hotels_Resrevation.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

using Unity;
using Unity.Injection;

namespace Hotels_Resrevation
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            //container.RegisterType(typeof(ApplicationDbContext));
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<IProfileRepository, ProfileRepository>();
            container.RegisterType<IImageRepository, ImageRepository>();
            container.RegisterType<ISearchRepository, SearchRepository>();
            container.RegisterType<IRoomRepository, RoomRepository>();
            container.RegisterType<IReservationRepository, ReservationRepository>();
            container.RegisterType<IFacilityRepository, FacilityRepository>();
            container.RegisterType<IReviewRepository, ReviewRepository>();
        }
    }
}