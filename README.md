# CodingExercise
Exeter coding exercise

Installation Notes:

  - Open the solution file
    - Once loaded in the solution explorer right click on the solution and select 'Restore NuGet packages' from the context menu.
  - Right click on CodingExercise.API project and select Set as Startup project
  - Open Web.config file and change the 'DefaultConnectionString' to point to you local SQL Server instance
  - open Package Manager Console and set the Default project to: CodingExercise.Data
    - run the following command: update-database
  - run the application and you shold be able to see and use the rudimentary UI that was set up for API testing.
  
  
  Third party packages:
    - Unity.WebAPI
    - AutoMapper
    - Moq
