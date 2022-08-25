using System;
using TechTalk.SpecFlow;

namespace ATMSpecFlow.Tests.StepDefinitions
{
    [Binding]
    public class CardHolderTestsStepDefinitions
    {
        public CardHolder testUser;
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
                testUser.Withdraw(amount);
            }
            catch (Exception ex)
            {
                testException = ex;
            }
        }

        [When(@"I deposit (.*) pounds in my account")]
        public void WhenIDepositPoundsInMyAccount(double amount)
        {
            try
            {
                testUser.Deposit(amount);
            }
            catch (Exception ex)
            {
                testException = ex;
            }
        }


        [Then(@"I should have (.*) pounds left in my account")]
        public void ThenIShouldHavePoundsLeftInMyAccount(double amount)
        {
            Assert.AreEqual(amount, testUser.Balance);
        }

        [Then(@"It should throw an exception")]
        public void ThenItShouldThrowAnException()
        {
            Assert.IsNotNull(testException);
            Assert.IsTrue(testException is ArgumentOutOfRangeException);
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
                testResult = testUser.CardNumCheck(testUser.CardNumber);
            }
            catch (Exception ex)
            {
                testException = ex;
            }


        }

        [Then(@"I should be able to access the ATM")]
        public void ThenIShouldBeAbleToAccessTheATM()
        {
            Assert.IsTrue(testResult);
        }

        [Then(@"I should not be able to access the ATM")]
        public void ThenIShouldNotBeAbleToAccessTheATM()
        {
            Assert.IsNotNull(testException);
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
                testResult = testUser.PinNumCheck(testUser.Pin);
            }
            catch (Exception ex)
            {
                testException = ex;
            }
        }




    }
}
