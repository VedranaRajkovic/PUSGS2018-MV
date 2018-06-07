namespace RepoDemo.Migrations
{
    using RepoDemo.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepoDemo.Persistance.DemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RepoDemo.Persistance.DemoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Services.AddOrUpdate(
                s => s.Name,
                new Service() { Name = "Service1" },
                new Service() { Name = "Service2" },
                new Service() { Name = "Service3" }
            );
            context.SaveChanges();

            Service service = context.Services.Where(sr => sr.Name == "Service1").FirstOrDefault();
            if (service != null && service.ServiceId != 0)
            {
                context.BranchOffices.AddOrUpdate(
                    bo => bo.Address,
                    new Branch() { Address = "Maksimova 3", Latitute = 1.0, Longitude = 1.0, ServiceId = service.ServiceId },
                    new Branch() { Address = "Balzakova 4", Latitute = 2.0, Longitude = 2.0, ServiceId = service.ServiceId }
                );
                context.SaveChanges();
            }
        }
    }
}
