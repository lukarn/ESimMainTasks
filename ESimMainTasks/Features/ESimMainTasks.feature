Feature: ESim Main Tasks

@train
Scenario: Check train activityss
	Given launch browser
	And go to BasePage
	And login to service
	When click Train button if it is present
	Then the timer to next train should be present