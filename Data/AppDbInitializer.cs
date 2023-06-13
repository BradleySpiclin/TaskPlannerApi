using System;
using TaskPlannerApi.Models;

namespace TaskPlannerApi.Data
{
    public class AppDbInitializer
    {
        public static void SeedDatabase(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (context != null)
                {
                    context.Database.EnsureCreated();

                    // Category
                    if (!context.Categories.Any())
                    {
                        context.Categories.AddRange(new List<Category>()
                        {
                                new Category()
                                {
                                    Name = "Home"
                                },
                                new Category()
                                {
                                    Name = "Work"
                                },
                                new Category()
                                {
                                    Name = "School"
                                },
                                new Category()
                                {
                                    Name = "Other"
                                },
                            });
                    }
                    // TaskItem
                    if (!context.TaskItems.Any())
                    {
                        context.TaskItems.AddRange(new List<TaskItem>()
                        {
                            new TaskItem()
                            {
                                Name = "Testing 1",
                                Comments = "Testing 1",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 1
                            },
                               new TaskItem()
                            {
                                Name = "Testing 10",
                                Comments = "Testing 10",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 1
                            },
                                  new TaskItem()
                            {
                                Name = "Testing 11",
                                Comments = "Testing 11",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 1
                            },
                            new TaskItem()
                            {
                                Name = "Testing 2",
                                Comments = "Testing 2",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 2
                            },
                            new TaskItem()
                            {
                                Name = "Testing 2",
                                Comments = "Testing 2",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 2
                            },
                            new TaskItem()
                            {
                                Name = "Testing 3",
                                Comments = "Testing 3",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 3
                            },
                              new TaskItem()
                            {
                                Name = "Testing 30",
                                Comments = "Testing 30",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 3
                            },
                            new TaskItem()
                            {
                                Name = "Testing 4",
                                Comments = "Testing 4",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 4
                            },
                            new TaskItem()
                            {
                                Name = "Testing 4",
                                Comments = "Testing 4",
                                DueDate = DateTime.Now,
                                IsComplete = false,
                                CategoryId = 4
                            },
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
