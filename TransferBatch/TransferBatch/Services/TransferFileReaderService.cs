using CsvHelper;
using CsvHelper.Configuration;
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

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ",",
                    HasHeaderRecord = false
                };

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<AccountTranfer>();
                    return records.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while reading the file: {ex.Message}");
            }
        }      

    }
}
