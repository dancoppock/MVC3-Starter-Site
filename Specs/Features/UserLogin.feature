Feature: User Authentication
	In order to access the site
	As a user
	I want to enter a username and password

Scenario: Login with correct username and password
	Given a user exists with username "admin" and password "password"
	Then that user should be able to login using "admin" and "password"

Scenario: Login with incorrect username and password
	Given a user exists with username "admin" and password "password"
	Then that user should not be able to login using "admin" and "badguy"
