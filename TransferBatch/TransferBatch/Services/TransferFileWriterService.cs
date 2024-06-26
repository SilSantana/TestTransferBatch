using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferBatch.Models;
using TransferBatch.Validations;

namespace TransferBatch.Services
{
    public abstract class TransferFileWriterService
    {

        private const string FILENAME = "TransferBatch_transfers.csv";

        // this method is responsible for writing the commission file
        public static void WriteTransferFile(string? filePath, List<TransferCommision> transferCommisions)
        {           
            try
            {

                FileValidations.ValidateFilePath(filePath);

                filePath += FILENAME;

                using (StreamWriter file = new(filePath))
                {
                    file.WriteLine("Account_ID,Total_Commission");
                   
                    foreach (TransferCommision transferCommision in transferCommisions)
                    {
                        file.WriteLine($"{transferCommision.AccountId},{Convert.ToString(transferCommision.TotalCommision, CultureInfo.InvariantCulture.NumberFormat)}");
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
