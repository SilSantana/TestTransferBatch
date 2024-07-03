using System.Text;
using TransferBatch.Models;
using TransferBatch.Validations;

namespace TransferBatch.Services
{
    public abstract class TransferFileWriterService
    {
        private const string FILENAME = "transferbatch.transfers.csv";

        public static async Task WriteTransferFileAsync(string? filePath, List<TransferCommision> transferCommisions)
        {           
            try
            {
                FileValidations.ValidateFilePath(filePath);

                var path = Path.GetDirectoryName(filePath);
                Random random = new();
                filePath = Path.Combine(path, random.Next(1, 10000) + FILENAME);

                int bufferSize = 4096; // Size buffer in bytes
                using (StreamWriter file = new(filePath, append: false, encoding: Encoding.UTF8, bufferSize))
                {
                    foreach (TransferCommision transferCommision in transferCommisions)
                    {
                        var commission = $"{transferCommision.AccountId},{transferCommision.TotalCommision.ToString("N0")}";
                        Console.WriteLine($"{transferCommision.AccountId},{transferCommision.TotalCommision.ToString("N0")}");
                        await file.WriteLineAsync(commission);
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
