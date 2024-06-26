using System.Globalization;
using TransferBatch.Models;
using TransferBatch.Validations;

namespace TransferBatch.Services
{
    public abstract class TransferFileReaderService
    {

        // this method is responsible for reading the transfer file and creating the account transfer objects
        public static List<AccountTranfer> ReadTransferFile(string? filePath)
        {            
            try
            {
                FileValidations.ValidateFilePath(filePath);

                FileValidations.ValidateFileExtension(filePath);                                                
                              
                string[] file = File.ReadAllLines(filePath); 
                FileValidations.ValidateFileContent(file);                  
                

                List<AccountTranfer> accountTranfers = [];               
                foreach (string line in file)
                {
                    string[] columns = line.Split(',');
                    AccountTranfer accountTranfer = new()
                    {
                        AccountId = columns[0],
                        TransferId = columns[1],
                        TotalTransferAmount = decimal.Parse(columns[2], CultureInfo.InvariantCulture.NumberFormat)
                    };

                    accountTranfers.Add(accountTranfer);
                }


                Console.WriteLine("The transfers file was read successfully!");

                return accountTranfers;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while reading the file: {ex.Message}", ex);
            }
        }

    }
}
