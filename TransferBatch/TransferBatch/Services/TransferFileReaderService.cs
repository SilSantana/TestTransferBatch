using System.Globalization;
using TransferBatch.Models;
using TransferBatch.Validations;

namespace TransferBatch.Services
{
    public abstract class TransferFileReaderService
    {
        public static List<AccountTranfer> ReadTransferFile(string? filePath)
        {            
            try
            {
                FileValidations.ValidateFilePath(filePath);

                FileValidations.ValidateFileExtension(filePath);


                string[] file = File.ReadAllLines(filePath); 
                FileValidations.ValidateFileContent(file);                  
                

                List<AccountTranfer> accountTranfers = [];               
                foreach (string transfer in file)
                {
                    string[] columns = transfer.Split(',');

                    FileValidations.IsValidFileContent(columns);

                    AccountTranfer accountTranfer = new()
                    {
                        AccountId = columns[0],
                        TransferId = columns[1],
                        TotalTransferAmount = decimal.Parse(columns[2], CultureInfo.InvariantCulture.NumberFormat)
                    };
                    accountTranfers.Add(accountTranfer);
                }

                return accountTranfers;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while reading the file: {ex.Message}");
            }
        }      

    }
}
