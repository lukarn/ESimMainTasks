Feature: ESim Main Tasks

@train
Scenario: Check train activity
	Given go to BasePage
	And login to service
	When click Train task button if it is present
	And click Trenuj button if it is present
	Then the timer to next train should be present

@work
Scenario: Check work activity
	Given go to BasePage
	And login to service
	When click Work task button if it is present
	And click Pracuj button if it is present
	Then check if work results are present