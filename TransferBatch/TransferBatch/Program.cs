// See https://aka.ms/new-console-template for more information
using TransferBatch.Services;


Console.WriteLine("***************** Calculator Account Transfer Commission ******************************");

Console.WriteLine("Inform the CVS path file: ");

string? filePath = Console.ReadLine();


var accountTransfers = TransferFileReaderService.ReadTransferFile(filePath);


CommissionCalculateService.CalculateCommission(accountTransfers);


Console.WriteLine("***************** End Calculator Account Transfer Commission ******************************");





