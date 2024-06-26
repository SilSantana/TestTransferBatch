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


    }
}
