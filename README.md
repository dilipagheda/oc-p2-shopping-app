# A Shopping cart App - .NET Core MVC

This project is a shopping cart app built with ASP .NET Core MVC. It is a 2nd project as part of the OpenClassrooms - Backend developer path - .Net Core. 
This project was given with all required unit tests. The unit tests were failing initially and goal was to implement the functionality so that unit tests will pass.

# Skills used
- ASP .NET Core, MVC
- Unit tests
- C#
- Produce an xUnit test execution report
- Fix an application according to a test execution report

# Approach for solving this project

I used below step by step approach for solving this project.

1. I ran all unit tests and took the inital state of the test results.
2. I ran the project and tested the application in the browser. I found issues (as mentioned in the issues/bugs section) and took a note of it.
3. I started solving each bug one by one by debugging the code using debugger, founding a root cause and then implementing the functionality or fix.
4. I noticed that at several places, functionality was not implemented at all. there were comments like 'To Do'. I implemented the functionality and then
   re-ran unit tests. I noticed that more tests passed. I tested functionality in the browser and it worked.
5. I repeated step 4 until all unit tests passed and functionality works 100% in the browser.

# Issues/Bugs
Initially, the project consisted of below bugs.
1. Clicking on the 'Add to cart' button doesn't actually add a given product to the cart.
2. Selecting a different language and clicking on 'Ok' button doesn't do anything.
3. Once product started being added to the cart, cart didn't show the right Total Quantity and Average Quantity.
4. Removing product from the cart wasn't working

# Difficulties encountered
During the course of this project, I encountered below difficulties and how I overcame it.
1. When user clicked 'Add to cart' button, product was not being added to the cart. In order to fix this bug, I debugged the code and found where the issue was originating from.
I noticed that in the Cart.cs, a property 'Lines' was assigned an expression which was creating a new list each time it was called. I figured that because of this, previous values of List was not being retained as new object is created each time. I fixed it using a singleton pattern where the expression creates new list only if it not created.
2. Fixing the failing test - UpdateProductQuanties was very interesting. The fix involved registering repository classes as Singleton and also updating their constructor
   so that we only create data once at the startup. I had to debug the unit test couple of times to fully understand what was going on. Debugging allowed me to understand
   that data was not being preserved because each time, Repository was instantiated, it was resetting the data.
