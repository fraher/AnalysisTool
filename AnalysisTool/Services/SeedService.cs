using AnalysisTool.Models;
using AnalysisTool.Persistence;
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
    public static class SeedService
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            
            // Populate Users
            if(_unitOfWork.Users.GetAll().Count() == 0)
            {
                List<User> users = new List<User>
                {
                    new User
                    {
                        Id = null,
                        UserName = "admin",
                        TypeOfUser = UserType.Administrator
                    },
                    new User
                    {
                        Id = null,
                        UserName = "patient123",
                        TypeOfUser = UserType.Patient,
                        PatientGender = Gender.Male,
                        BirthYear = 1950
                    },
                    new User
                    {
                        Id = null,
                        UserName = "doctor123",
                        TypeOfUser = UserType.Provider,
                        ProviderName = "Dr. Xavier",
                        Institution = "Xavier School for the Gifted"
                    }
                };

                foreach(var user in users)
                {
                    _unitOfWork.Users.Add(user);
                }
            }
            

            // Populate Assessments
            if (_unitOfWork.Assessments.GetAll().Count() == 0)
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

                foreach(var assessment in assessments)
                {
                    _unitOfWork.Assessments.Add(assessment);
                }
                

            }

        }



    }
}
