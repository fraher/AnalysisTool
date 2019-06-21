using AnalysisTool.Models;
using AnalysisTool.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalysisTool.Services
{
    public class SeedService
    {        
        /// <summary>
        /// This method establishes all user types in the system.
        /// </summary>
        /// <param name="services">Takes in the services provider managing the application.</param>
        public static void SeedRoles(IServiceProvider services)
        {
            RoleManager<Role> _roleManager;
            
            _roleManager = services.GetRequiredService<RoleManager<Role>>();

            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                Role role = new Role();
                role.Name = "Administrator";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Participant").Result)
            {
                Role role = new Role();
                role.Name = "Participant";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        /// <summary>
        /// This is a development only method which creates a default admin user and a default participant
        /// </summary>
        /// <param name="services">Takes in the services provider managing the application.</param>
        public static void SeedUsers(IServiceProvider services)
        {
            UserManager<User> _userManager;            
            
            _userManager = services.GetRequiredService<UserManager<User>>();            

            if(_userManager.FindByNameAsync("admin").Result == null)
            {
                User user = new User();
                user.UserName = "admin";
                user.Email = "admin@nowhere.com";

                IdentityResult userResult = _userManager.CreateAsync(user, "Test123!").Result;

                if(userResult.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }

            if (_userManager.FindByNameAsync("bob").Result == null)
            {
                User user = new User();
                user.UserName = "bob";
                user.Email = "bob@nowhere.com";

                IdentityResult userResult = _userManager.CreateAsync(user, "Test123!").Result;

                if (userResult.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Participant").Wait();
                }
            }


        }

        /// <summary>
        /// This is a development only method which populates the database with default assessments.
        /// </summary>
        /// <param name="unitOfWork">This provides a stateful model connection to the database.</param>
        public static void SeedAssessments(IUnitOfWork unitOfWork)
        {            

            // Populate Assessments
            if (unitOfWork.Assessments.GetAll().Count() == 0)
            {

                List<Assessment> assessments = new List<Assessment>
                {
                    new Assessment
                    {
                        Id = null,
                        Name = "Mock Stroop Test",
                        Version = "1.0.0",
                        Instructions = "Press the letter corresponding color shown (r = RED, g = GREEN, b = BLUE, y = YELLOW). Press the appropriate key when the text shows.",
                        Steps = new List<AssessmentStep>
                        {
                            new AssessmentStep
                            {
                                StepNumber = 1,
                                Name = "Question 1",
                                InformativeText = "Step 1 Instruction",
                                PossiblePoints = 1,
                                DisplayParams = new DisplayParams
                                {
                                    DisplayType = "text",
                                    Content = "Blue",
                                    Css = "color:Purple; font-size:72px"
                                },
                                ResponseParams = new ResponseParams
                                {
                                    ResponseType = "text"
                                }
                            },
                            new AssessmentStep
                            {
                                StepNumber = 2,
                                Name = "Question 2",
                                InformativeText = "Step 2 Instruction",
                                PossiblePoints = 1,
                                DisplayParams = new DisplayParams
                                {
                                    DisplayType = "image",
                                    Content = "https://images.unsplash.com/photo-1518655061710-5ccf392c275a?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1934&q=80",
                                    Css = "width: 50%;"

                                },
                                ResponseParams = new ResponseParams
                                {
                                    ResponseType = "text"
                                }
                            }
                        }
                    }
                };

                foreach (var assessment in assessments)
                {
                    unitOfWork.Assessments.Add(assessment);
                }


            }
        }
        
    }
}
