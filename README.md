# SpecFlowDemo
Demonstration of specification-by-example on GitHub pages using SpecFlow, NUnit 3 and Selenium Web-Driver

## Synopsis

The project is demonstration of Specification-By-Example (BDD) on GitHub login and dashboard pages. With Cucumber (Gherkin) features implemented by SpecFlow. The implementation of the steps is using Selenium WebDriver using best practices of Selenium (PageObjects,etc.) together with best practices of SpecFlow.

## Code Example
```Gherkin
@Login
Feature: Login success
	In order to access to my Github account
	As a user with existing account
	I want to be able to sign in to GitHub 
  
Scenario: Login with email and password
	Given I am in the login page
	When I login by email and password
	Then I should see the dashboard
```
##### The step implementation:
```C#
        [When(@"I login by email and password")]
        public void WhenILoginByEmailAndPassword()
        {
            var user = TestConfiguration.GitHubUser;
            loginPage.LoginSuccess(user.Email, user.Password);
        }
```

## Motivation

This project was created to demonstrate how to write good executable specifications in SpecFlow and Selenium using best practices
see my presentation:
http://www.slideshare.net/LirazShay/bdd-with-specflow-and-selenium-webdriver

## Installation

Visual Studio 2012, 2013 or 2015, even the free Community edition is perfect. Install the SpecFlow extension (downloadable from Visual Studio Gallery).
Also need NUnit 3 Test Adapter extension

Download the project, build and run the tests
