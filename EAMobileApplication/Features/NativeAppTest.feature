Feature: NativeAppTest
	Test React Native based Android application

Scenario: Test basic controls of Native app
	Given I launch the application
	And I enter the email and password as
		| Email          | Password    |
		| karthik@ea.com | Password123 |
	And I perform slider operation 

