using Bank_Application;
namespace BankApp.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void AccountCreatingTesting()
        {
            //Arrange
            var testAccount = new Account
            {
                User = "Testing",
                Password = "Testing",
                Name = "Testing",
                AccountNumber = 1,
            };

            //ACT
            testAccount.User = "NoTesting";

            //ASSERT
            Assert.Equal("Testing", testAccount.User);
        }
    }
}