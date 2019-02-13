select * from dbo.Assessments

select * from dbo.AssessmentSteps

INSERT INTO dbo.Assessments (AssessmentName, AssessmentVersion) VALUES ('Stroop Test', '1.0.0')

INSERT INTO dbo.AssessmentSteps (AssessmentId, StepName, Instructions, MetaData, PossiblePoints) 
VALUES (1, 'Question 1', 'Press the letter corresponding color shown (r = RED, g = GREEN, b = BLUE, y = YELLOW). Press the appropriate key when the text shows.', '{ "inputType": "keyPress", "text": "Green", "css": "color:Blue; font-size:72px" }', 1)



INSERT INTO dbo.AssessmentSteps (AssessmentId, StepName, Instructions, MetaData, PossiblePoints) 
VALUES (1, 'Question 2', 'Press the letter corresponding color shown (r = RED, g = GREEN, b = BLUE, y = YELLOW). Press the appropriate key when the text shows.', '{ "inputType": "keyPress", "instructions": "Press the letter corresponding color shown (r = RED, g = GREEN, b = BLUE, y = YELLOW). Press the appropriate key when the text shows.", "text": "Blue", "css": "color:Yellow; font-size:72px" }', 1)



INSERT INTO dbo.AssessmentSteps (AssessmentId, StepName, Instructions, MetaData, PossiblePoints) 
VALUES (1, 'Question 3', 'Press the letter corresponding color shown (r = RED, g = GREEN, b = BLUE, y = YELLOW). Press the appropriate key when the text shows.', '{ "inputType": "textbox", "instructions": "Press the letter corresponding color shown (r = RED, g = GREEN, b = BLUE, y = YELLOW). Press the appropriate key when the text shows." }', 1)

