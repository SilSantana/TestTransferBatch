using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferBatch.Models;
using TransferBatch.Validations;

namespace TransferBatch.Services
{
    public abstract class TransferFileWriterService
    {

        private const string FILENAME = "commission.csv";

        // this method is responsible for writing the commission file
        public static void WriteTransferFile(string? filePath, List<TransferCommision> transferCommisions)
        {           
            try
            {

                FileValidations.ValidateFilePath(filePath);


                using (StreamWriter file = new StreamWriter(filePath))
                {
                    file.WriteLine("Account_ID,Total_Commission");
                   
                    foreach (TransferCommision transferCommision in transferCommisions)
                    {
                        file.WriteLine($"{transferCommision.AccountId},{transferCommision.TotalCommision}");
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
