using TransferBatch.Models;

namespace TransferBatch.Services
{
    public abstract class TransferFileReaderService
    {

        // this method is responsible for reading the transfer file and creating the account transfer objects
        public static List<AccountTranfer> ReadTransferFile(string? filePath)
        {            
            try
            {

                if (string.IsNullOrEmpty(filePath))                
                    throw new Exception("The file path is empty, please provide the file path!");
                

                if (!filePath.EndsWith(".csv"))                
                    throw new Exception("The file extension is invalid, please provide a CSV file!");
                
                              
                string[] lines = File.ReadAllLines(filePath);                
                if (lines.Length == 0)               
                    throw new Exception("The file is empty, please provide the file!");                    
                

                List<AccountTranfer> accountTranfers = [];               
                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');
                    AccountTranfer accountTranfer = new()
                    {
                        AccountId = columns[0],
                        TransferId = columns[1],
                        TotalTransferAmount = Convert.ToDecimal(columns[2])
                    };

                    accountTranfers.Add(accountTranfer);
                    Console.WriteLine(string.Join(" | ", accountTranfer));
                }

                return accountTranfers;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while reading the file: {ex.Message}", ex);
            }
        }

    }
}
