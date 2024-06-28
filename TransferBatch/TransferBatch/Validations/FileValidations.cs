namespace TransferBatch.Validations
{
    public abstract class FileValidations
    {
        public static void ValidateFilePath(string? filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new Exception("The file path is empty, please provide the file path!");
        }

        public static void ValidateFileExtension(string? filePath)
        {
            if (filePath != null && !filePath.EndsWith(".csv"))
                throw new Exception("The file extension is invalid, please provide a CSV file!");
        }

        public static void ValidateFileContent(string[] file)
        {
            if (file.Length == 0)
                throw new Exception("The file is empty, please provide the file!");
        }

        public static void IsValidFileContent(string[] itens)
        {
            if (string.IsNullOrWhiteSpace(itens[0]))
                throw new Exception("The content file path is invalid, please provide a valid AccountId!");

            if (string.IsNullOrWhiteSpace(itens[1]))
                throw new Exception("The content file path is invalid, please provide a valid TransferId!");

            if (string.IsNullOrWhiteSpace(itens[2]))
                throw new Exception("The content file path is invalid, please provide a valid Total Transfer Amount!");

            if (!decimal.TryParse(itens[2], out _))
                throw new Exception("The content file path is invalid, please provide a valid Total Transfer Amount!");
        }

    }
}
