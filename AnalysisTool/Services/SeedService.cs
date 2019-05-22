using AnalysisTool.Models;
using AnalysisTool.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AnalysisTool.Models.SystemConstants;

namespace AnalysisTool.Services
{
    public class SeedService
    {        
        public static void SeedUsers(IServiceProvider services)
        {
            UserManager<User> _userManager;
            RoleManager<Role> _roleManager;            
            
            _userManager = services.GetRequiredService<UserManager<User>>();
            _roleManager = services.GetRequiredService<RoleManager<Role>>();
           
            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                Role role = new Role();
                role.Name = "Administrator";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if(_userManager.FindByNameAsync("admin").Result == null)
            {
                User user = new User();
                user.UserName = "admin";
                user.Email = "fraher@gmail.com";

                IdentityResult userResult = _userManager.CreateAsync(user, "Test123!").Result;

                if(userResult.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
            

            
        }

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
