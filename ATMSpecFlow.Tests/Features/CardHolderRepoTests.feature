Feature: CardHolderRepoTests

As a user of the ATM, I would like my information to be displayed correctly and updated correctly

@tag1
Scenario: Retriving card holder information using card number
	Given I am a valid card holder with number 1234567890123456
	When I ask for my details to be displayed
	Then My information should be displayed correctly
