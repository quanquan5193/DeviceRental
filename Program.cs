using Autofac;
using DeviceRental.Database;
using DeviceRental.Handler;
using DeviceRental.Infrastructure;
using DeviceRental.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DeviceRental
{
    static class Program
    {
        public static IContainer Container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Container = ConfigAutofac();
            Application.Run(new MainMenu(Container.Resolve<HandlerRegister>()));
        }

        static IContainer ConfigAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>().SingleInstance();
            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>();
            builder.RegisterType<HandlerRegister>().As<HandlerRegister>().SingleInstance();

            builder.RegisterAssemblyTypes(typeof(DeviceRentalRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterType<MainMenu>();
            return builder.Build();
        }
    }
}
