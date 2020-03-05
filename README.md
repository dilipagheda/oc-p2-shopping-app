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

# Test execution reports
## Before
```
Group Name: P2FixAnAppDotNetCode.Tests
Duration: 0:00:00.05
7 test(s) failed
0 test(s) skipped
1 test(s) passed
```

### After
```
Group Name: P2FixAnAppDotNetCode.Tests
Duration: 0:00:00.046
0 test(s) failed
0 test(s) skipped
8 test(s) passed
```
```
PM> dotnet test
Test run for C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\bin\Debug\netcoreapp2.0\P2FixAnAppDotNetCode.Tests.dll(.NETCoreApp,Version=v2.0)
Microsoft (R) Test Execution Command Line Tool Version 16.3.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
dotnet : [xUnit.net 00:00:00.9761755]     P2FixAnAppDotNetCode.Tests.ProductServiceTests.GetProductById [FAIL]
At line:1 char:1
+ dotnet test --logger trx
+ ~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : NotSpecified: ([xUnit.net 00:0...ductById [FAIL]:String) [], RemoteException
    + FullyQualifiedErrorId : NativeCommandError
 
[xUnit.net 00:00:00.9888339]     P2FixAnAppDotNetCode.Tests.LanguageServiceTests.SetCulture [FAIL]


[xUnit.net 00:00:00.9891493]     P2FixAnAppDotNetCode.Tests.CartTests.GetTotalValue [FAIL]


[xUnit.net 00:00:00.9916362]     P2FixAnAppDotNetCode.Tests.CartTests.AddItemInCart [FAIL]


[xUnit.net 00:00:00.9924281]     P2FixAnAppDotNetCode.Tests.CartTests.GetAverageValue [FAIL]


[xUnit.net 00:00:00.9927295]     P2FixAnAppDotNetCode.Tests.CartTests.FindProductInCartLines [FAIL]


[xUnit.net 00:00:00.9929795]     P2FixAnAppDotNetCode.Tests.ProductServiceTests.UpdateProductQuantities [FAIL]


  X P2FixAnAppDotNetCode.Tests.ProductServiceTests.GetProductById [6ms]
  Error Message:
   System.NullReferenceException : Object reference not set to an instance of an object.
  Stack Trace:
     at P2FixAnAppDotNetCode.Tests.ProductServiceTests.GetProductById() in C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\ProductServiceTests.cs:line 75
  X P2FixAnAppDotNetCode.Tests.LanguageServiceTests.SetCulture [6ms]
  Error Message:
   Assert.Same() Failure
Expected: fr
Actual:   
  Stack Trace:
     at P2FixAnAppDotNetCode.Tests.LanguageServiceTests.SetCulture() in C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\LanguageServiceTests.cs:line 22
  X P2FixAnAppDotNetCode.Tests.CartTests.GetTotalValue [13ms]
  Error Message:
   Assert.Equal() Failure
Expected: 1085
Actual:   0
  Stack Trace:
     at P2FixAnAppDotNetCode.Tests.CartTests.GetTotalValue() in C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\CartTests.cs:line 62
  X P2FixAnAppDotNetCode.Tests.CartTests.AddItemInCart [2ms]
  Error Message:
   Assert.NotEmpty() Failure
  Stack Trace:
     at P2FixAnAppDotNetCode.Tests.CartTests.AddItemInCart() in C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\CartTests.cs:line 25
  X P2FixAnAppDotNetCode.Tests.CartTests.GetAverageValue [1ms]
  Error Message:
   Assert.Equal() Failure
Expected: 304.993333333333
Actual:   0
  Stack Trace:
     at P2FixAnAppDotNetCode.Tests.CartTests.GetAverageValue() in C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\CartTests.cs:line 44
  X P2FixAnAppDotNetCode.Tests.CartTests.FindProductInCartLines [1ms]
  Error Message:
   Assert.NotNull() Failure
  Stack Trace:
     at P2FixAnAppDotNetCode.Tests.CartTests.FindProductInCartLines() in C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\CartTests.cs:line 74
  X P2FixAnAppDotNetCode.Tests.ProductServiceTests.UpdateProductQuantities [6ms]
  Error Message:
   Assert.Equal() Failure
Expected: 9
Actual:   10
  Stack Trace:
     at P2FixAnAppDotNetCode.Tests.ProductServiceTests.UpdateProductQuantities() in C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\ProductServiceTests.cs:line 45
Results File: C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\TestResults\dilip_LAPTOP-KI7J7KKM_2020-03-04_20_49_12.trx

Test Run Failed.


Total tests: 8
     Passed: 1
     Failed: 7
 Total time: 1.7254 Seconds
```


```
PM> dotnet test --logger trx
Test run for C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\bin\Debug\netcoreapp2.0\P2FixAnAppDotNetCode.Tests.dll(.NETCoreApp,Version=v2.0)
Microsoft (R) Test Execution Command Line Tool Version 16.3.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.
Results File: C:\Projects\oc-p2-shopping-app\P2FixAnAppDotNetCode.Tests\TestResults\dilip_LAPTOP-KI7J7KKM_2020-03-05_20_31_22.trx

Test Run Successful.
Total tests: 8
     Passed: 8
 Total time: 1.7820 Seconds
```
