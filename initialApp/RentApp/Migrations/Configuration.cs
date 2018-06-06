namespace RentApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RentApp.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<RentApp.Persistance.RADBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RentApp.Persistance.RADBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Manager" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }


            context.AppUsers.AddOrUpdate(

                  u => u.FullName,

                  new AppUser() { FullName = "Admin Adminovic" }

            );

            context.AppUsers.AddOrUpdate(

                p => p.FullName,

                new AppUser() { FullName = "AppUser AppUserovic" }

            );
            Branch b = new Branch();
            Service s1 = new Service();
            Service s2 = new Service();
            Vehicle v1 = new Vehicle();
            Vehicle v2 = new Vehicle();
            Rent rnt = new Rent();
            TypeOfVehicle typeofv = new TypeOfVehicle();

            typeofv.Name = "Caravan";
            v1.Manufactor = "Golf";
            v1.Model = "5";
            v1.PricePerHour = 10;
            v1.Unavailable = false;
            v1.Year = 2008;
            v1.Type = typeofv;

            typeofv.Vehicles = new System.Collections.Generic.List<Vehicle>();
            typeofv.Vehicles.Add(v1);
          
           
            typeofv.Name = "Cabriolet";
            v2.Manufactor = "Peugeot";
            v2.Model = "206";
            v2.PricePerHour = 12;
            v2.Unavailable = false;
            v2.Year = 2015;
            v2.Type = typeofv;

            typeofv.Vehicles = new System.Collections.Generic.List<Vehicle>();
            typeofv.Vehicles.Add(v2);

            b.Address = "Ul.1/23";
            b.Latitude = 2222;
            b.Longitude = 3333;

            s1.Name = "Service 1";
            s1.Email = "servis@gmail.com";
            s1.Description = "servis s1";
            s1.Branches = new System.Collections.Generic.List<Branch>();
            s1.Branches.Add(b);

            s2.Name = "Service 2";
            s2.Email = "servis2@gmail.com";
            s2.Description = "servis s2";
            s2.Branches = new System.Collections.Generic.List<Branch>();
            s2.Branches.Add(b);

            context.Branches.AddOrUpdate(b);
            context.Services.AddOrUpdate(s1);
            context.Services.AddOrUpdate(s2);
            context.Vehicles.AddOrUpdate(v1);
            context.Vehicles.AddOrUpdate(v2);
            context.Types.AddOrUpdate(typeofv);
            
            context.SaveChanges();

            var userStore = new UserStore<RAIdentityUser>(context);
            var userManager = new UserManager<RAIdentityUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var _appUser = context.AppUsers.FirstOrDefault(a => a.FullName == "Admin Adminovic");
                var user = new RAIdentityUser() { Id = "admin", UserName = "admin", Email = "admin@yahoo.com", PasswordHash = RAIdentityUser.HashPassword("admin"), AppUserId = _appUser.Id };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu"))

            {

                var _appUser = context.AppUsers.FirstOrDefault(a => a.FullName == "AppUser AppUserovic");
                var user = new RAIdentityUser() { Id = "appu", UserName = "appu", Email = "appu@yahoo.com", PasswordHash = RAIdentityUser.HashPassword("appu"), AppUserId = _appUser.Id };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");

            }
            Branch b1 = new Branch();
            Branch b2 = new Branch();
            Service se1 = new Service();
            Service se2 = new Service();
            Vehicle vh1 = new Vehicle();
            Vehicle vh2 = new Vehicle();
            // Rent rnt = new Rent();
            TypeOfVehicle typeofv1 = new TypeOfVehicle();
            TypeOfVehicle typeofv2 = new TypeOfVehicle();

            typeofv1.Name = "Caravan";
            vh1.Manufactor = "Golf";
            vh1.Model = "5";
            vh1.PricePerHour = 10;
            vh1.Unavailable = false;
            vh1.Year = 2008;
            vh1.Type = typeofv1;

            //   typeofv.Vehicles = new System.Collections.Generic.List<Vehicle>();
            // typeofv.Vehicles.Add(v1);
            b1.Address = "Ul.1/23";
            b1.Latitude = 2222;
            b1.Longitude = 3333;


            typeofv2.Name = "Cabriolet";
            vh2.Manufactor = "Peugeot";
            vh2.Model = "206";
            vh2.PricePerHour = 12;
            vh2.Unavailable = false;
            vh2.Year = 2015;
            vh2.Type = typeofv2;

            // typeofv.Vehicles = new System.Collections.Generic.List<Vehicle>();
            // typeofv.Vehicles.Add(v2);

            b2.Address = "Ul.1/23";
            b2.Latitude = 2222;
            b2.Longitude = 3333;

            se1.Name = "Service 1";
            se1.Email = "servis@gmail.com";
            se1.Description = "servis s1";
            se1.Branches = new System.Collections.Generic.List<Branch>();
            se1.Branches.Add(b1);
            se1.Vehicles = new System.Collections.Generic.List<Vehicle>();
            se1.Vehicles.Add(vh1);

            se2.Name = "Service 2";
            se2.Email = "servis2@gmail.com";
            se2.Description = "servis s2";
            se2.Branches = new System.Collections.Generic.List<Branch>();
            se2.Branches.Add(b2);
            se2.Vehicles = new System.Collections.Generic.List<Vehicle>();
            se2.Vehicles.Add(vh2);

            Service[] services = { se1, se2 };
            context.Services.AddOrUpdate(s => s.Name, services);
            // context.SaveChanges();
            SaveChanges(context);
            // context.Services.AddOrUpdate(s2);

            Branch[] branches = { b1, b2 };
            context.Branches.AddOrUpdate(bb => bb.Address, branches);
            // context.SaveChanges();
            SaveChanges(context);

            Vehicle[] vehicles = { vh1, vh2 };
            context.Vehicles.AddOrUpdate(v => v.Model, vehicles);
            //context.SaveChanges();
            SaveChanges(context);

            TypeOfVehicle[] types = { typeofv1, typeofv2 };
            context.Types.AddOrUpdate(t => t.Name, types);
            //context.SaveChanges();
            SaveChanges(context);

        }
        private static void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }
    }
}
