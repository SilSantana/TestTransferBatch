using TransferBatch.Models;
using TransferBatch.Services;

namespace UnitTest
{
    [TestClass]
    public class CommissionCalculateTests
    {

        [TestMethod]
        public void CalculateCommission_Should_ReturnSuccesfully()
        {
            // arrange
            List<AccountTranfer> accountTransfers = new List<AccountTranfer>() 
            {
                new()
                {
                    AccountId = "A10",
                    TransferId = new Random().Next(1,10000).ToString(),
                    TotalTransferAmount = 100.00m
                },               
                new()
                {
                    AccountId = "A10",
                    TransferId = new Random().Next(1,10000).ToString(),
                    TotalTransferAmount = 300.00m
                },
                new()
                {
                    AccountId = "A11",
                    TransferId = new Random().Next(1,10000).ToString(),
                    TotalTransferAmount = 100.00m
                },
                new()
                {
                    AccountId = "A10",
                    TransferId = new Random().Next(1,10000).ToString(),
                    TotalTransferAmount = 200.00m
                }
            };

            //action
            var result = CommissionCalculateService.CalculateCommission(accountTransfers);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
        }


        [TestMethod]
        public void CalculateCommission_WhenOneTransation_Should_ReturnNull()
        {
            // arrange
            List<AccountTranfer> accountTransfers = new()
            {
                new()
                {
                    AccountId = "A10",
                    TransferId = new Random().Next(1,10000).ToString(),
                    TotalTransferAmount = 100.00m
                }
            };

            //action
            var result = CommissionCalculateService.CalculateCommission(accountTransfers);

            //assert
            Assert.IsNull(result);
        }

    }
}