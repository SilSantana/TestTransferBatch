// See https://aka.ms/new-console-template for more information
using TransferBatch.Models;
using TransferBatch.Services;


Console.WriteLine("***************** Calculator Account Transfer Commission ******************************");

Console.WriteLine("Inform the CVS path file: ");

string? filePath = Console.ReadLine();


List<AccountTranfer> accountTransfers = TransferFileReaderService.ReadTransferFile(filePath);

List<TransferCommision> commissions = CommissionCalculateService.CalculateCommission(accountTransfers);

TransferFileWriterService.WriteTransferFile(filePath, commissions);


Console.WriteLine("***************** End Calculator Account Transfer Commission ******************************");





