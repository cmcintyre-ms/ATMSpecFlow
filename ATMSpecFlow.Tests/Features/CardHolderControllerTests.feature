Feature: CardHolderControllerTests

As a user of the ATM, I would like my information to be displayed and updated correctly

# Testing HttpGet GetCardHolder
Scenario: Retriving card holder information using valid card number
	Given I am a valid card holder with number 1234567890123456
	When I ask for my card details to be retrived
	Then A OkObjectResult should be returned


Scenario: Not retriving any information for no card number
	Given I do not have a valid card number
	When I ask for my card details to be retrived
	Then A NoContentResult should be returned


# Testing HttpGet GetBalance
Scenario: Successfully returning the card holders correct balance
	Given I have a card number of 1234567890123456 and I want to check my balance
	When I ask for my balance
	Then A OkObjectResult should be returned


# Testing HttpPut UpdateCardNumber
Scenario: Changing the card number due to card loss/stolen etc as a valid user
	Given I am a valid card holder and I lost card number 1234567890123456
	When I loose my card or it gets stolen
	Then A OkResult should be returned


Scenario: Trying to change the card number with an invalid card user
	Given I am not a valid card user
	When I loose my card or it gets stolen
	Then A NoContentResult should be returned


# Testing HttpPut UpdatePinNumber
Scenario: Changing the pin number as a valid user
	Given I wish to change the pin number for card number 1234567890123456
	When I go to change my pin on the ATM
	Then A OkResult should be returned

Scenario: Trying to change the pin number as an invalid card user
	Given I am not a valid card user
	When I go to change my pin on the ATM
	Then A NoContentResult should be returned


# Testing HttpPut UpdateLastName
Scenario: Changing my last name as a valid user
	Given I am a valid card holder with surname Doe
	When I want to change my last name to Smith
	Then A OkResult should be returned

Scenario: Changing my last name as an invalid user
	Given I am not a valid card user
	When I want to change my last name to Smith
	Then A NoContentResult should be returned
	
