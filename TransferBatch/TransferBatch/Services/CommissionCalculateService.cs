using TransferBatch.Models;

namespace TransferBatch.Services
{
    public abstract class CommissionCalculateService
    {
        private const decimal COMMISSION_RATE = 0.10m;

        public static List<TransferCommision> CalculateCommission(List<AccountTranfer> accountTransfers)
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
            
            if (transferCommisions.Count > 0)
            {
                return transferCommisions.GroupBy(c => c.AccountId)
                    .Select(c => new TransferCommision
                   {
                       AccountId = c.Key,
                       TotalCommision = c.Sum(x => x.TotalCommision)
                   }).ToList();
            }

            return null;                    
        }

    }
}
