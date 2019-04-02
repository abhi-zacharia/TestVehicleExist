Feature: Vehicle Test feature
	In order to test the functionality of insurance
	As a tester
	I want to test iuf the vehicle exist function works

Scenario: Vehicle exists
	Given I am on the home page	
	When I enter reg number 'OV12UYY'
	And press find vehicle button
	Then the result should include vehicle

Scenario: Vehicle does not exist
	Given I am on the home page	
	When I enter reg number 'AB12CDE'
	And press find vehicle button
	Then the result should not include vehicle