using ATMSpecFlow.Server;
using ATMSpecFlow.Server.Services;
using System;
using System.Diagnostics.Contracts;
using TechTalk.SpecFlow;

namespace ATMSpecFlow.Tests.StepDefinitions
{
    [Binding]
    public class CardHolderTestsStepDefinitions
    {
        public CardHolder testUser;
        public CardHolderService testService = new CardHolderService();
        public Exception testException;
        public bool testResult;

        [Given(@"I am a valid user of the ATM")]
        public void GivenIAmAValidUserOfTheATM()
        {
            testUser = new CardHolder();
        }

        [Given(@"I have (.*) pounds in my account")]
        public void GivenIHavePoundsInMyAccount(double amount)
        {
            testUser.Balance = amount;
        }

        [When(@"I withdraw (.*) pounds from my account")]
        public void WhenIWithdrawPoundsFromMyAccount(double amount)
        {
            try
            {
                testService.Withdraw(testUser, amount);
            }
            catch (Exception ex) when (ex is AmountCannotBeMoreThanBalanceException ||
                                       ex is AmountLessThanZeroException)
            {
                testException = ex;
            }
        }

        [When(@"I deposit (.*) pounds in my account")]
        public void WhenIDepositPoundsInMyAccount(double amount)
        {
            try
            {
                testService.Deposit(testUser, amount);
            }
            catch (Exception ex) when (ex is AmountCannotBeMoreThanBalanceException ||
                                       ex is AmountLessThanZeroException)
            {
                testException = ex;
            }
        }


        [Then(@"I should have (.*) pounds left in my account")]
        public void ThenIShouldHavePoundsLeftInMyAccount(double amount)
        {
            Assert.AreEqual(amount, testUser.Balance);
        }

        [Then(@"It should throw an AmountLessThanZeroException")]
        public void ThenItShouldThrowAnAmountLessThanZeroException()
        {
            Assert.IsNotNull(testException);
            Assert.IsTrue(testException is AmountLessThanZeroException);
        }

        [Then(@"It should throw an AmountCannotBeMoreThanBalanceException")]
        public void ThenItShouldThrowAnAmountCannotBeMoreThanBalanceException()
        {
            Assert.IsNotNull(testException);
            Assert.IsTrue(testException is AmountCannotBeMoreThanBalanceException);
        }

        [Given(@"I have a card with number (.*)")]
        public void GivenIHaveACardWithNumberCardNum(string cardNum)
        {
            testUser.CardNumber = cardNum;
        }

        [When(@"I enter in the card details to the ATM")]
        public void WhenIEnterInTheCardDetailsToTheATM()
        {
            try
            {
                testResult = testService.CardNumCheck(testUser, testUser.CardNumber);
            }
            catch (Exception ex) when (ex is IncorrectDigitsCardNumberException)
            {
                testException = ex;
            }


        }

        [Then(@"I should be able to access the ATM")]
        public void ThenIShouldBeAbleToAccessTheATM()
        {
            Assert.IsTrue(testResult);
        }

        [Then(@"It should throw an IncorrectDigitsCardNumberException")]
        public void ThenItShouldThrowAnIncorrectDigitsCardNumberException()
        {
            Assert.IsNotNull(testException);
            Assert.IsTrue(testException is IncorrectDigitsCardNumberException);
        }


        [Given(@"I have pin number (.*)")]
        public void GivenIHavePinNumber(int pin)
        {
            testUser.Pin = pin;
        }

        [When(@"I enter my pin number")]
        public void WhenIEnterMyPinNumber()
        {
            try
            {
                testResult = testService.PinNumCheck(testUser, testUser.Pin);
            }
            catch (Exception ex) when (ex is IncorrectDigitsPinNumberException)
            {
                testException = ex;
            }
        }

        [Then(@"It should throw an IncorrectDigitsPinNumberException")]
        public void ThenItShouldThrowAnIncorrectDigitsPinNumberException()
        {
            Assert.IsNotNull(testException);
            Assert.IsTrue(testException is IncorrectDigitsPinNumberException);
        }



    }
}
