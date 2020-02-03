# MarsRoverChallenge
 https://code.google.com/archive/p/marsrovertechchallenge/

This is an implementation of the mars rover google challenge.

It is a console application that will ask the user step by step for input and outputs the final positions of the rovers.

User input is validated, and will continue to prompt the user until valid input is received.

**Assumptions**

1. The consumer of the application will handle any exceptions and input validations (in this the current implementation of the console app.)

2. Rovers don't collide during movement but pass by one another.

3. If two rovers are at the same endpoint an exception is thrown

   

**Running the program**

The application will run in Visual Studio Community 2019 with .NetCore 3.1

A console application is also in the `build` folder in the root directory.

**Running the Tests**

The test framework is NUnit. Best run through VS 2019 but can also be run using the NUnit console runner.



**Project Breakdown**

***MarsRoverChallenge***

This is the console UI for the application, it manages all user input and feeds it to the `Mars` project.

***Mars***

This project contains all of the logic for the program. It is a separate project so any kind of UI can be swapped out as long as the correct input is provided.

***Tests***

Test project that will contain and run all the NUnit tests for all the projects

