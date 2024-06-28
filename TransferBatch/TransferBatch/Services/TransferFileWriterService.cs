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

                Random random = new();

                filePath = path +@"\" + random.Next(1,10000) + FILENAME;

                using (StreamWriter file = new(filePath))
                {                   
                    foreach (TransferCommision transferCommision in transferCommisions)
                    {
                        file.WriteLine($"{transferCommision.AccountId},{transferCommision.TotalCommision.ToString("N0")}");

                        Console.WriteLine($"{transferCommision.AccountId},{transferCommision.TotalCommision.ToString("N0")}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while writing the file: {ex.Message}");
            }
        }

    }
}
