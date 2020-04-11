using Microsoft.AspNetCore.Identity;
using SimpleExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExam.Data
{
    public class DataSeed
    {
        // https://github.com/dotnet-architecture/eShopOnWeb/blob/f3f74a342e9ff10d4c0e7f76f411c29479da4fc2/src/Infrastructure/Identity/AppIdentityDbContextSeed.cs
        public static async Task SeedUsersAndRolesAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole("admin"));
            var sampleUser = new AppUser { UserName = "student@gmail.com", Email = "student@gmail.com" };
            await userManager.CreateAsync(sampleUser, "Password1.");

            string adminUserName = "yigith1@gmail.com";
            var adminUser = new AppUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, "Password1.");
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, "admin");
        }

        public static async Task SeedSampleExamAsync(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            var user = await userManager.FindByNameAsync("student@gmail.com");

            if (user == null || context.Exams.Any())
                return;

            var exam = new Exam
            {
                Name = "Sample Exam",
                Questions = new List<Question>
                {
                    new Question
                    {
                        SortOrder = 1,
                        Text = "What's the color of a sea?",
                        Options = new List<Option>
                        {
                            new Option { SortOrder = 1, Text = "Blue", IsCorrect = true },
                            new Option { SortOrder = 2, Text = "Yellow" },
                        }
                    },
                    new Question
                    {
                        SortOrder = 2,
                        Text = "Where does the sun rise?",
                        Options = new List<Option>
                        {
                            new Option { SortOrder = 1, Text = "North" },
                            new Option { SortOrder = 2, Text = "East", IsCorrect = true },
                            new Option { SortOrder = 3, Text = "South" },
                            new Option { SortOrder = 4, Text = "West" },
                        }
                    }
                }
            };

            context.Add(exam);
            context.SaveChanges();

            var sampleStudentGroup = new Group
            {
                GroupName = "Student Group 1 ",
                StudentGroups = new List<StudentGroup> { new StudentGroup { AppUserId = user.Id } },
                ExamAssignments = new List<ExamAssignment>
                {
                    new ExamAssignment
                    {
                        ExamId = exam.Id,
                        ExamAssignmentSetting = new ExamAssignmentSetting
                        {
                             Duration = 5,
                             IsRetakeable = true
                        }
                    }
                }
            };
            context.Groups.Add(sampleStudentGroup);
            context.SaveChanges();
        }
    }
}
