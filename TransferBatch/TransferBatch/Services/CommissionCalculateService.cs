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

            foreach (AccountTranfer transfer in accountTransfers.Where(c => c.TotalTransferAmount < maxTotalTransferAmount))
            { 
                TransferCommision transferCommission = new()
                {
                    AccountId = transfer.AccountId,
                    TotalCommision = transfer.TotalTransferAmount * COMMISSION_RATE
                };

                transferCommisions.Add(transferCommission);              
            }

            var newTransferCommisions = transferCommisions.GroupBy(c => c.AccountId)
                .Select(c => new TransferCommision
                {
                    AccountId = c.Key,
                    TotalCommision = c.Sum(x => x.TotalCommision)
                }).ToList();


            Console.WriteLine("The commission was calculated successfully!");

            TransferFileWriterService.WriteTransferFile("C:\\projetos\\teste\\TestTransferBatch\\File\\", newTransferCommisions);
        }

    }
}
