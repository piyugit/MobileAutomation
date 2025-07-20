Feature: Login
	Test the login feature

@smoke
Scenario: Login functionality of application
	Given I launch the application
	And I skip the welcome splash screen
	Then I see the schedule page
	When I click the breadcrumb menu button
	And I click the Login button
	Then I see the user login screen
	And I enter the username and password as
		| UserName       | Password    |
		| karthik@ea.com | Password123 |
	And I click the login button
