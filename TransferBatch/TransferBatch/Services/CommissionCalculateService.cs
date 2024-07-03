using TransferBatch.Models;

namespace TransferBatch.Services
{
    public abstract class CommissionCalculateService
    {
        private const decimal COMMISSION_RATE = 0.10m;

        public static List<TransferCommision> CalculateCommission(List<AccountTranfer> accountTransfers)
        {
            if (accountTransfers == null || accountTransfers.Count == 0)
                return new();


            var maxTotalTransferAmount = accountTransfers.Max(c => c.TotalTransferAmount);
            var transferCommisions = new Dictionary<string, decimal>();

            foreach (var transfer in accountTransfers)
            {
                if (transfer.TotalTransferAmount < maxTotalTransferAmount)
                {
                    if (!transferCommisions.ContainsKey(transfer.AccountId))
                    {
                        transferCommisions[transfer.AccountId] = 0;
                    }
                    transferCommisions[transfer.AccountId] += transfer.TotalTransferAmount * COMMISSION_RATE;
                }
            }

            return transferCommisions.Select(c => new TransferCommision
            {
                AccountId = c.Key,
                TotalCommision = c.Value
            }).ToList();
        }

    }
}
