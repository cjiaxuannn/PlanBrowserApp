using PlanBrowserAPI.Models;

namespace PlanBrowserAPI.Data {
  public static class DbInitializer {
    public static void Seed(AppDbContext context) {
      //if (context.Plans.Any()) return;

      // Delete all existing plans
      context.Plans.RemoveRange(context.Plans);
      context.SaveChanges();

      context.Plans.AddRange(
        new Plan {
          Name = "Singtel Lite", Type = "Prepaid", DataLimit = "2GB", ValidityDays = 7, Price = 10, Description = "Short-term basic internet access."
        },
        new Plan {
          Name = "Singtel Value", Type = "Prepaid", DataLimit = "10GB", ValidityDays = 30, Price = 35, Description = "Affordable data with good validity."
        },
        new Plan {
          Name = "Singtel Power 20", Type = "Prepaid", DataLimit = "20GB", ValidityDays = 30, Price = 50, Description = "For heavy users needing more data."
        },
        new Plan {
          Name = "Singtel Weekly Pass", Type = "Prepaid", DataLimit = "5GB", ValidityDays = 7, Price = 15, Description = "Weekly internet for travelers or temp use."
        },
        new Plan {
          Name = "Singtel Unlimited Prepaid", Type = "Prepaid", DataLimit = "Unlimited", ValidityDays = 30, Price = 80, Description = "Unlimited prepaid with fair usage."
        },
        new Plan {
          Name = "Singtel Flexi 30", Type = "Postpaid", DataLimit = "30GB", ValidityDays = 30, Price = 60, Description = "Flexible postpaid plan with moderate data."
        },
        new Plan {
          Name = "Singtel Prime", Type = "Postpaid", DataLimit = "50GB", ValidityDays = 30, Price = 90, Description = "Premium postpaid for power users."
        },
        new Plan {
          Name = "Singtel Unlimited Postpaid", Type = "Postpaid", DataLimit = "Unlimited", ValidityDays = 30, Price = 120, Description = "Truly unlimited postpaid plan."
        },
        new Plan {
          Name = "Singtel Family Pack", Type = "Postpaid", DataLimit = "100GB", ValidityDays = 30, Price = 150, Description = "Shared data plan for families."
        },
        new Plan {
          Name = "Singtel Student Plan", Type = "Prepaid", DataLimit = "12GB", ValidityDays = 30, Price = 25, Description = "Affordable data plan for students."
        }
      );

      context.SaveChanges();
    }
  }
}