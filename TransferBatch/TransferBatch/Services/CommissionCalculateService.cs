using System.Globalization;
using TransferBatch.Models;

namespace TransferBatch.Services
{
    public abstract class CommissionCalculateService
    {
        private const decimal COMMISSION_RATE = 0.10m;


        // this service is responsible for calculating the commission for each account transfer
        public static void CalculateCommission(List<AccountTranfer> accountTransfers)
        {

            List<TransferCommision> transferCommisions = [];

            var maxTotalTransferAmount = accountTransfers.Max(c => c.TotalTransferAmount);

            Console.WriteLine($"The max total transfer amount: {maxTotalTransferAmount}");


            foreach (AccountTranfer transfer in accountTransfers)
            {
                if (transfer.TotalTransferAmount != maxTotalTransferAmount)
                {
                    
                    decimal commission = transfer.TotalTransferAmount * COMMISSION_RATE;

                    TransferCommision commision = new()
                    {
                        AccountId = transfer.AccountId,
                        TotalCommision = commission
                    };

                    transferCommisions.Add(commision);

                    Console.WriteLine($"The commission for the transfer {transfer.TransferId} : {transfer.AccountId} is {commission}");
                }   
            }


        }


    }
}
