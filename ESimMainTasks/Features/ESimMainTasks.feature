Feature: ESim Main Tasks

@train
Scenario: Check train activityss
	Given launch browser
	And go to BasePage
	And login to service
	When click Train task button if it is present
	And click Trenuj button
	Then the timer to next train should be present