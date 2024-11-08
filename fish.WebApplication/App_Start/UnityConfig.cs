using fish.Repositories.Interfaces;
using fish.Repositories.Repositories;
using fish.Services.Interfaces;
using fish.Services.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace fish.WebApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // Đăng ký các Repository
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IBookingRepository, BookingRepository>();
            container.RegisterType<IServiceModelRepository, ServiceModelRepository>();

            // Đăng ký các Service
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IHomeService, HomeService>();
            container.RegisterType<IDoctorService, DoctorService>();

            container.RegisterType<IAdminService, AdminService>();



            container.RegisterType<IDichVuService, DichVuService>();

            // Đăng ký IIndexService
            container.RegisterType<IIndex1Service, Index1Service>();
            container.RegisterType<IIndex3Service, Index3Service>();

            container.RegisterType<IIndex4Service, Index4Service>();

            container.RegisterType<IIndex5Service, Index5Service>();

            container.RegisterType<IIndex6Service, Index6Service>();






            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}