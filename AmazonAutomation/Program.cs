// See https://aka.ms/new-console-template for more information
using AmazonAutomation.Tests;

Console.WriteLine("Amazon Automation Framework (C# - Selenium - NUnit)");
AmazonTests amazonTests = new AmazonTests();

amazonTests.Setup();

amazonTests.SelectCategoryTest();

amazonTests.SearchItemTest();

amazonTests.CloseBrowserTest();
