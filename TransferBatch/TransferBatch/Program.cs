// See https://aka.ms/new-console-template for more information
using TransferBatch.Models;
using TransferBatch.Services;


class Program
{
    static void Main(string[] args)
    {           
        string filePath = args[0];

        List<AccountTranfer> accountTransfers = TransferFileReaderService.ReadTransferFile(filePath);

        List<TransferCommision> commissions = CommissionCalculateService.CalculateCommission(accountTransfers);

        Task.Run(async () => await TransferFileWriterService.WriteTransferFileAsync(filePath, commissions)).GetAwaiter().GetResult();
    }
}
