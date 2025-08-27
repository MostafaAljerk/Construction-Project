using Data;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;

namespace ConstructionConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (ConstructionContext Context =new ConstructionContext())
            {
                Context.Database.EnsureCreated();
            }

            //Add();
            GetProject();
            Update();
            Delete(5);

        }

        private static void Delete(int ProjectId)
        {
            using (var context = new ConstructionContext())
            {
                var House = context.ConstructionProjects.Find(ProjectId);
                if (House == null)
                {
                    return;
                }
                context.ConstructionProjects.Remove(House);
                context.SaveChanges();
            }
        }

       

        private static void Update()
        {
            using (var context=new ConstructionContext())
            {
                var Project = context.
                    ConstructionProjects.
                    Include(c => c.ProjectTasks).
                    FirstOrDefault(c => c.Name == "School construction project");
                Project.Status = "Pending";
                context.SaveChanges();

            }
        }

        private static void GetProject()
        {
            using (ConstructionContext context=new ConstructionContext())
            {
                var Constructions=context.ConstructionProjects.
                    Include(c=>c.ProjectTasks).
                    Include(cp=>cp.PaymentTransactions)
                    .ToList();
                foreach (var construction in Constructions)
                {
                    Console.WriteLine(construction.Name+" " +construction.Budget);
                    foreach (var project in construction.ProjectTasks)
                    {
                        Console.WriteLine(project.Name + " " +project.Description);
                    }
                    foreach (var payment in construction.PaymentTransactions)
                    {
                        Console.WriteLine(payment.TransactionType +" " +payment.Equals);
                    }
                }
            }
        }

        private static void Add()
        {
            var Task1 = new ProjectTask
            {
                Name = "Excavating the foundations",
                Status = "In Progress",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MinValue,
                Description = "pending"
            };
            var Task2 = new ProjectTask
            {
                Name = "Pouring concrete",
                Status = "Pending",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MinValue,
                Description = "pending"

            };
            

            var Employee = new Employee
            {
                FirstName = "Ahmad",
                LastName = "AboHmed",
                Role = "Engineer",
                


            };
            var Payment = new PaymentTransaction
            {
                TransactionType = "Incoming",
                Amount = 20000,
                Description = "First payment from the client",
                TransactionDate = DateTime.UtcNow,
            };
            var Project = new ConstructionProject()
            {
                Name = "House construction project",
                Budget = 80000,
                Status = "Active",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MinValue,
                ProjectTasks=new List<ProjectTask> { Task1, Task2 },
                PaymentTransactions=new List<PaymentTransaction> { Payment },
                
            };
            
            using (var context = new ConstructionContext())
            {
                context.ConstructionProjects.Add(Project);
                context.Employees.Add(Employee);
               
                context.SaveChanges();
            }

            


        }
    }
}
