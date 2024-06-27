using TransferBatch.Models;
using TransferBatch.Validations;

namespace TransferBatch.Services
{
    public abstract class TransferFileWriterService
    {
        private const string FILENAME = "transferbatch.transfers.csv";

        public static void WriteTransferFile(string? filePath, List<TransferCommision> transferCommisions)
        {           
            try
            {
                FileValidations.ValidateFilePath(filePath);

                var path = Path.GetDirectoryName(filePath);  
                filePath = path +@"\" + FILENAME;

                using (StreamWriter file = new(filePath))
                {                   
                    foreach (TransferCommision transferCommision in transferCommisions)
                    {
                        file.WriteLine($"{transferCommision.AccountId},{transferCommision.TotalCommision.ToString("N0")}");
                    }
                }

                Console.WriteLine("The commission file was created successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while writing the file: {ex.Message}");
            }
        }

    }
}
