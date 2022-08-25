Feature: CardHolderTests

As a user of the ATM
I expect all services within the ATM to be processed correctly

Background:
	Given I am a valid user of the ATM

	# Testing Withdraw Method
Scenario: Withdraw Money from ATM With Valid Amount
	Given I have <account> pounds in my account
	When I withdraw <withdraw> pounds from my account
	Then I should have <expected> pounds left in my account

	Examples: 
	| account | withdraw | expected |
	| 100     | 30       | 70       |
	| 200     | 20       | 180      |
	| 300     | 100      | 200      |


Scenario: Trying to withdraw too much money from bank account
	Given I have <account> pounds in my account
	When I withdraw <withdraw> pounds from my account
	Then It should throw an AmountCannotBeMoreThanBalanceException

	Examples: 
	| account | withdraw |
	| 10      | 15       |
	| 0       | 500      |
	| 20      | 21       |


Scenario: Trying to withdraw a negative amount of money from account
	Given I have 0 pounds in my account
	When I withdraw -10 pounds from my account
	Then It should throw an AmountLessThanZeroException


	# Testing Deposit Method
Scenario: Deposit Money from ATM with valid amount
	Given I have <account> pounds in my account
	When I deposit <deposit> pounds in my account
	Then I should have <expected> pounds left in my account

	Examples: 
	| account | deposit | expected |
	| 100     | 1       | 101      |
	| 200     | 10      | 210      |
	| 0       | 5       | 5        |


Scenario: Trying to deposit an invalid amount of money
	Given I have 20 pounds in my account
	When I deposit -20 pounds in my account
	Then It should throw an AmountLessThanZeroException


	# Testing CardNumCheck Method
Scenario: Card number entered is valid
	Given I have a card with number 1234567890123456
	When I enter in the card details to the ATM
	Then I should be able to access the ATM


Scenario: Card number entered is invalid
	Given I have a card with number <cardNumber>
	When I enter in the card details to the ATM
	Then It should throw an IncorrectDigitsCardNumberException

	Examples: 
	| cardNumber      |
	| 1               |
	| 111111          |
	| 111111111111111 |


	# Testing PinNumCheck method
Scenario:  Pin Number entered is valid
	Given I have pin number 1111
	When I enter my pin number
	Then I should be able to access the ATM


Scenario: Pin number entered is invalid
	Given I have pin number <pinNumber>
	When I enter my pin number
	Then It should throw an IncorrectDigitsPinNumberException

	Examples: 
	| pinNumber |
	| 1         |
	| 11        |
	| 111       |
