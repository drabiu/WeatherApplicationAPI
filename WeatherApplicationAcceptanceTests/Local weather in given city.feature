Feature: Local weather in given city
	As a delegated employee
	I want to check what the weather is like in a city and country of my choosing
	So that I know how to dress for the business trip over there.

@warsaw
Scenario: Check weather for Warsaw
	Given a webpage with a form
	And I type in "Poland"
	And I type in "Warsaw"
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Warsaw, Poland according to the official weather reports

@gdansk
Scenario: Check weather for Gdansk
	Given a webpage with a form
	And I type in "Poland"
	And I type in "Gdansk"
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Gdansk, Poland according to the official weather reports

@berlin
Scenario: Check weather for Berlin
	Given a webpage with a form
	And I type in "Germany"
	And I type in "Berlin"
	When I submit the form
	Then I receive the temperature and humidity conditions on the day for Berlin, Germany according to the official weather reports 
