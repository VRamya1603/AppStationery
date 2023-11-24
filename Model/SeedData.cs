using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppStationery.Model
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {
                //Branch
                if (context == null || context.Branch == null)
                {
                    throw new ArgumentNullException("Null AppDbContext");
                }
                if (context.Branch.Any())
                {
                    return;   
                }
                context.Branch.AddRange(
                    new Branch
                    {
                        BranchName = "Branch1"
                    },
                    new Branch
                    {
                        BranchName = "Branch2"
                    }
                );
                context.SaveChanges();

                //ApplicationUser
                if (context == null || context.ApplicationUser == null)
                {
                    throw new ArgumentNullException("Null AppDbContext");
                }
                if (context.ApplicationUser.Any())
                {
                    return;   
                }
                context.ApplicationUser.AddRange(
                    new ApplicationUser
                    {
                        UserName = "User1"
                    },
                    new ApplicationUser
                    {
                        UserName = "User2"
                    }
                );
                context.SaveChanges();

                //PrinitingStationery
                if (context == null || context.PrintingStationery == null)
                {
                    throw new ArgumentNullException("Null AppDbContext");
                }
                if (context.PrintingStationery.Any())
                {
                    return;   
                }
                context.PrintingStationery.AddRange(
                    new PrintingStationery
                    {
                        Name = "Printing Paper"
                    },
                    new PrintingStationery
                    {
                        Name = "PhotoPaper"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}