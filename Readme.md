# Fish Dreams 
## Longitudinal Tracking of Cognitive Impairment

**Introduction**
This tool allows providers to track cognitive assessments for high-risk MCI patients. 
This open-source project is designed to provide a standarized modular environment for digital psychometric analysis.
The goal of this tool is to assist PCPs, Specialists, and Researchers obtain assessment data outside of the hospital environment at set frequencies.
The software is not meant to replace existing providers, but provide additional data points to support a diagnosis.

**How it Works**
This software is a web-based application that provides a portal for both patients and providers to access and perform assessments or assign assessments depending on their user rights. 
Each user will create a de-identified User Name in the hospital setting with the provider which will then be linked to their patient record through an EMR. 
The software does not contain PHI, rather it only tracks the measures which are assigned. The results of the measures will be accessible via the application for the individual user thorugh a reporting page.
Providers can access the data through a secure API or directly through the application.

This web-based application is intended to be run on touch-enabled devices which include laptops and other mobile devices, not excluding other modalities which allow for a touch experience and have a modern browser.

**Presentation**:
<a href='https://docs.google.com/presentation/d/1uVMEWisfYvHvDJ-3m79pI14m7TlM3S0GTDikzXEQ-sk/edit#slide=id.g25f6af9dd6_0_0'>Slide Deck</a>

**GitHub Repo**:
<a href= 'https://github.com/fraher/AnalysisTool'>Fish Dreams Analysis Tool</a>

**Demo Images**:
<a href= 'https://github.com/fraher/AnalysisTool/blob/master/AnalysisTool/Demo%20Images/'>Images</a>
  

**Development**
The software is designed to be a mobile-first responsive web application. The following technologies are being utilized:

### UI Design
1. Bootstrap
2. Datatables.net
3. Jquery
4. Responsive design
5. Mobile ready

### Frameworks
1. .Net Core 2.2
2. MongoClient

### Database
1. MongoDb

### Assessment Standard Template
In order to create the standard that will be used for all assessment types, a commonly utilized script type should be used. In this case we are using the JavaScript Object Notation (JSON) format. Due to the anticipated dynamic nature of each assessment this is expected to evolve prior to the release of version 1.0. The goal is to establish a template that can vary greatly but using common elements and steps.

The following example is the current state of the template for a mock test containing 4 questions:

```javascript

{
    "AssessmentId": "ABCD",
    "Name": "Mock Stroop Test",
    "Version": "1.0.0",
    "Instructions": "Press the letter corresponding color shown (r = RED, g = GREEN, b = BLUE, y = YELLOW). Press the appropriate key when the text shows.",
    "Steps": [
        {
            "StepNumber": 1,
            "Name": "Question 1",      
            "InformativeText": "Step 1 Instruction", 
            "PossiblePoints": 1,      
            "DisplayParams": {
                    "DisplayType": "text",
                    "Content": "Blue",
                    "Css": "color:Purple; font-size:72px" 
                }, 
            "ResponseParams": { 
                "ResponseType": "text",                 
            }            
        },
        {
            "StepNumber": 2,
            "Name": "Question 2",      
            "InformativeText": "Step 2 Instruction", 
            "PossiblePoints": 1,      
            "DisplayParams": {
                    "DisplayType": "text",
                    "Content": "Yellow",
                    "Css": "color:Blue; font-size:72px" 
                }, 
            "ResponseParams": { 
                "ResponseType": "True or False",                 
            }            
        }

    ]
}




```


### Milestones
<b>Milestone 1</b>	

<i>Planning - 2/1/2019 - 4/12/2019</i>
- [x]	Concept Approval	
- [x]	Identify Requirements	
- [ ]	Establish Risks	
- [x]	Identify Tools	
- [x]	Develop Budget	
- [x]	Receive Grant/Award	
		
<b>Milestone 2</b>

<i>Research and Development -	2/1/2019 - 6/30/2019</i>
- [ ]	Identify Subject Matter Experts	
- [ ]	Research Cognitive Assessments	
- [ ]	Identify Assessments	
- [ ]	Develop Standard Assessment Template	
- [ ]	Implement Requirements	
- [x]	Configure and Implement CI/CD	
- [ ]	Develop Software	
- [ ]	Develop Static Project Site	
		
<b>Milestone 3</b>

<i>Verification Testing	- 7/1/2019 - 7/31/2019</i>
- [ ]	Perform Test Cases	
- [ ]	Perform Hotfixes	
		
<b>Milestone 4</b>

<i>User Acceptance Testing -	8/1/2019 - 8/23/2019</i>
- [ ]	Deploy to Demo Site	
- [ ]	Collect User Experience Data	
- [ ]	Evaluate Results	
- [ ]	Perform Hotfixes	
		
<b>Milestone 5</b>

<i>Release Documentation -	8/24/2019 - 8/31/2019</i>
- [ ] User Guide
- [ ] Release Notes
		
<b>Milestone 6</b>

<i>Release	- 9/1/2019</i>
- [ ]	Roll-out v1.0 with Disclaimer	
		
<b>Milestone 7</b>

<i>Next Steps	- 9/2/2019 - *</i>
- [ ]	Discuss v2.0 as Product	
- [ ]	FDA Requirements	
- [ ]	Research Assessment Licenses	

### Current Members
* Sarah Price - sarah.price@utexas.edu
* Adriana Cardenas - adri.cardenas@utexas.edu
* CJ Fraher - fraher@gmail.com

### Acknowledgements
We would first like to thank the LifeSci Hack conference organizers for giving us the opporunity to help the community and open-source healthcare world. These members are: Sarah Sharif, Suliman Sharif, Scott Collins, and Amanda Ross

http://www.lifescihack.com/

This project could not have started without the wonderful work and effort of the hackathon team, FishDreams!

* Jessica Moore Bonner
* Reva Schweitzer 
* Sarah Price
* Adriana Cardenas
* CJ Fraher 

This project still continues today thanks to those who supported the LifeSci Hack event, a big shout out to:
* moz://a
* The Leona M. and Harry B. Helmsley Charitable Trust

### Credits
Royalty free test images currently in use are provided through <a href='https://unsplash.com/'>Unsplash</a>

### License
<a href='https://opensource.org/licenses/MIT'>MIT License</a>
