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
            var groupedAccountTransfers = accountTransfers.GroupBy(x =>  x.AccountId);


            foreach (AccountTranfer accountTransfer in groupedAccountTransfers)
            {

                // não aplicar comissão para transferencia com maior valor por conta
                if (accountTransfer.TotalTransferAmount != accountTransfers.Where(x => x.AccountId == accountTransfer.AccountId).Max(c => c.TotalTransferAmount))
                {
                    
                    decimal commission = accountTransfer.TotalTransferAmount * COMMISSION_RATE;

                    TransferCommision commision = new()
                    {
                        AccountId = accountTransfer.AccountId,
                        TotalCommision = commission
                    };

                    transferCommisions.Add(commision);

                    Console.WriteLine($"The commission for the transfer {accountTransfer.TransferId} is {commission}");
                }
                else
                {
                    Console.WriteLine($"The transfer {accountTransfer.TransferId} has the highest value for the account {accountTransfer.AccountId}, so it will not be charged a commission");
                    continue;
                }  
             
            }
        }


    }
}
