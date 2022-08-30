using ATMSpecFlow.Server;
using ATMSpecFlow.Server.Controllers;
using ATMSpecFlow.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using TechTalk.SpecFlow;

namespace ATMSpecFlow.Tests.StepDefinitions
{
    [Binding]
    public class CardHolderControllerTestsStepDefinitions
    {
        static Mock<ICardHolderRepo> mockRepo = new Mock<ICardHolderRepo>();
        CardHolderController controller;
        IActionResult testActionResult;

        List<CardHolder> cardHolderList = new List<CardHolder>
        {
            new CardHolder
            {
                FirstName = "Test",
                LastName = "User",
                CardNumber = "1234567890123456",
                Balance = 1000.00,
                Pin = 1234
            },
            new CardHolder
            {
                FirstName = "John",
                LastName = "Doe",
                CardNumber = "4563215985623147",
                Balance = 50.00,
                Pin = 4567
            },
            new CardHolder
            {
                FirstName = "Jane",
                LastName = "Smith",
                CardNumber = "9876543210321654",
                Balance = 10.00,
                Pin = 9876
            }
        };

        public string cardNumber;
        public CardHolder testUser;

        [Given(@"I am a valid card holder with number (.*)")]
        public void GivenIAmAValidCardHolderWithNumber(string cardNum)
        {
            mockRepo.Setup(c => c.GetCardHolderInfo(cardNum))
                .Returns(cardHolderList.SingleOrDefault(x => x.CardNumber == cardNum));

            cardNumber = cardNum;
        }

        [When(@"I ask for my card details to be retrived")]
        public void WhenIAskForMyDetailsToBeDisplayed()
        {
            controller = new CardHolderController(mockRepo.Object);
            testActionResult = controller.GetCardHolder(cardNumber);

        }

        [Then(@"A OkObjectResult should be returned")]
        public void ThenMyInformationShouldBeDisplayedCorrectly()
        {
            Assert.IsNotNull(testActionResult);
            Assert.IsInstanceOfType(testActionResult, typeof(OkObjectResult));
            Assert.IsNotInstanceOfType(testActionResult, typeof(NoContentResult));
        }

        [Given(@"I do not have a valid card number")]
        public void GivenIDoNotHaveAValidCardNumber()
        {
            cardNumber = null;

            mockRepo.Setup(c => c.GetCardHolderInfo(cardNumber))
                .Returns(cardHolderList.SingleOrDefault(x => x.CardNumber == cardNumber));
        }

        [Then(@"A NoContentResult should be returned")]
        public void ThenANoContentResultShouldBeReturned()
        {
            Assert.IsNotNull(testActionResult);
            Assert.IsInstanceOfType(testActionResult, typeof(NoContentResult));
            Assert.IsNotInstanceOfType(testActionResult, typeof(OkObjectResult));
        }

        [Given(@"I have a card number of (.*) and I want to check my balance")]
        public void GivenIAmAValidCardUserOfTheATM(string cardNum)
        {
            testUser = cardHolderList.FirstOrDefault(x => x.CardNumber == cardNum);

            mockRepo.Setup(c => c.GetBalanceForCardHolder(testUser))
                .Returns(testUser.Balance);
        }

        [When(@"I ask for my balance")]
        public void WhenIAskForMyBalance()
        {
            controller = new CardHolderController(mockRepo.Object);
            testActionResult = controller.GetBalance(testUser);
        }

        [Given(@"I am a valid card holder and I lost card number (.*)")]
        public void GivenIAmAValidCardHolderAndILostCardNumber(string cardNum)
        {
            testUser = cardHolderList.FirstOrDefault(x => x.CardNumber == cardNum);

            mockRepo.Setup(c => c.UpdateCardHolderCardNumber(testUser));
        }


        [When(@"I loose my card or it gets stolen")]
        public void WhenILooseMyCardOrItGetsStolen()
        {
            controller = new CardHolderController(mockRepo.Object);
            testActionResult = controller.UpdateCardNumber(testUser);
        }

        [Then(@"The ATM should be able to generate me a new card number and return an OkResult")]
        public void ThenTheATMShouldBeAbleToGenerateMeANewCardNumber()
        {
            Assert.IsNotNull(testActionResult);
            Assert.IsInstanceOfType(testActionResult, typeof(OkResult));
        }

        [Given(@"I am not a valid card user")]
        public void GivenIAmNotAValidCardUser()
        {
            testUser = null;
        }

        [Given(@"I wish to change the pin number for card number (.*)")]
        public void GivenIWishToChangeThePinNumberForCardNumber(string cardNum)
        {
            testUser = cardHolderList.FirstOrDefault(x => x.CardNumber == cardNum);

            mockRepo.Setup(c => c.UpdateCardHolderPinNumber(testUser));
        }

        [When(@"I go to change my pin on the ATM")]
        public void WhenIGoToChangeMyPinOnTheATM()
        {
            controller = new CardHolderController(mockRepo.Object);
            testActionResult = controller.UpdatePinNumber(testUser);
        }

        [Then(@"A OkResult should be returned")]
        public void ThenAOkResultShouldBeReturned()
        {
            Assert.IsNotNull(testActionResult);
            Assert.IsInstanceOfType(testActionResult, typeof(OkResult));
        }

        [Given(@"I am a valid card holder with surname (.*)")]
        public void GivenIAmAValidCardHolderWithSurnameDoe(string lastName)
        {
            testUser = cardHolderList.FirstOrDefault(x => x.LastName == lastName);
            mockRepo.Setup(c => c.UpdateCardHolderLastName(testUser, lastName));
        }


        [When(@"I want to change my last name to (.*)")]
        public void WhenIWantToChangeMyLastNameToSmith(string lastName)
        {
            controller = new CardHolderController(mockRepo.Object);
            testActionResult =  controller.UpdateLastName(testUser, lastName);
        }


    }
}
