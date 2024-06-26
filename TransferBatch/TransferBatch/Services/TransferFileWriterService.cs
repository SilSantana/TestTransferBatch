using System.Globalization;
using TransferBatch.Models;
using TransferBatch.Validations;

namespace TransferBatch.Services
{
    public abstract class TransferFileWriterService
    {
        private const string FILENAME = "transferbatch_transfers.csv";

        // this method is responsible for writing the commission file
        public static void WriteTransferFile(string? filePath, List<TransferCommision> transferCommisions)
        {           
            try
            {
                FileValidations.ValidateFilePath(filePath);
                filePath += FILENAME;

                using (StreamWriter file = new(filePath))
                {                   
                    foreach (TransferCommision transferCommision in transferCommisions)
                    {
                        file.WriteLine($"{transferCommision.AccountId},{transferCommision.TotalCommision.ToString(CultureInfo.InvariantCulture.NumberFormat)}");
                    }
                }

                Console.WriteLine("The commission file was created successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while writing the file: {ex.Message}", ex);
            }
        }

    }
}
