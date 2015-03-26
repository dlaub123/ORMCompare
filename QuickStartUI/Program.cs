using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickStartEntities;
using QuickStartEntitiesEF;

// NOTES
// 1) Name DA & EF Models as similarly as possible (may require post-model designer property changes to match names)
// 2) copy full contents of both DA & EF app config files into console app config file
// 3) add two core refs for each DA & EF in addition to model ref
// 4) update syntax a) EF requires explict object/table name in dbcontext refs, e.g. dbContext(.Customers).Add and b) syntax Remove vs. Delete
// 5) resolve namespace collsion on object/table, e.g. QuickStartEntities(EF).Customer
// 6) requires local sql server db with a single customer table...

namespace QuickStartUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DoItDA();  // do it with Telerik Data Access
            DoItEF();  // do it with Microsoft Entity Framework
        }
        static void DoItDA()
        {
            using (var dbContext = new QuickStartEntities.QuickStartEntities())
            {
                // Add a new Customer.
                QuickStartEntities.Customer newCustomer = new QuickStartEntities.Customer();
                newCustomer.Name = "New Customer";
                newCustomer.DateCreated = DateTime.Now;
                dbContext.Add(newCustomer);
                // Add another new Customer.
                QuickStartEntities.Customer newCustomer2 = new QuickStartEntities.Customer();
                newCustomer2.Name = "New Customer 2";
                newCustomer2.DateCreated = DateTime.Now;
                dbContext.Add(newCustomer2);
                // Commit new customers to the database.
                dbContext.SaveChanges();
                // Get the first Customer using LINQ and modify it.
                QuickStartEntities.Customer firstCustomer = dbContext.Customers.FirstOrDefault();
                firstCustomer.Name = firstCustomer.Name + "_Updated";
                // Commit changes to the database.
                dbContext.SaveChanges();
                // Use LINQ to retrieve Customer with name 'New Customer'.
                QuickStartEntities.Customer customerToDelete = (from c in dbContext.Customers
                                             where c.Name == "New Customer 2"
                                             select c).FirstOrDefault();
                // Delete the 'New Customer' from the database.
                dbContext.Delete(customerToDelete);
                // Commit changes to the database.
                dbContext.SaveChanges();
            }
            Console.Write("All changes executed properly, press any key to close.");
            Console.ReadKey();
        }

        static void DoItEF()
        {
            using (var dbContext = new QuickStartEntitiesEF.QuickStartDBEntitiesEF())
            {
                QuickStartEntitiesEF.Customer newCustomer = new QuickStartEntitiesEF.Customer();
                newCustomer.Name = "New Customer";
                newCustomer.DateCreated = DateTime.Now;
                dbContext.Customers.Add(newCustomer);  // vs. dbContext.Add(newCustomer)
                // Add another new Customer.
                QuickStartEntitiesEF.Customer newCustomer2 = new QuickStartEntitiesEF.Customer();
                newCustomer2.Name = "New Customer 2";
                newCustomer2.DateCreated = DateTime.Now;
                dbContext.Customers.Add(newCustomer2);  // vs. dbContext.Add(newCustomer)
                // Commit new customers to the database.
                dbContext.SaveChanges();
                // Get the first Customer using LINQ and modify it.
                QuickStartEntitiesEF.Customer firstCustomer = dbContext.Customers.FirstOrDefault();
                firstCustomer.Name = firstCustomer.Name + "_Updated";
                // Commit changes to the database.
                dbContext.SaveChanges();
                // Use LINQ to retrieve Customer with name 'New Customer'.
                QuickStartEntitiesEF.Customer customerToDelete = (from c in dbContext.Customers
                                                                where c.Name == "New Customer 2"
                                                                select c).FirstOrDefault();
                // Delete the 'New Customer' from the database.
                dbContext.Customers.Remove(customerToDelete); // vs. dbContext.Delete(customerToDelete);
                // Commit changes to the database.
                dbContext.SaveChanges();
            }
            Console.Write("All changes executed properly, press any key to close.");
            Console.ReadKey();
        }
    }

}
