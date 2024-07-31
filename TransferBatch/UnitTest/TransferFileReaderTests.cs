using TransferBatch.Services;

namespace UnitTest
{
    [TestClass]
    public class TransferFileReaderTests
    {

        [TestMethod]
        public void ReadTransferFile_Should_ReturnSuccesfully()
        {
            // arrange
            var filePath = @"C:\projetos\teste\TestTransferBatch\File\sample.transfers.csv";

            //action
            var result = TransferFileReaderService.ReadTransferFile(filePath);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 4);     
        }


        [TestMethod]
        public void ReadTransferFile_WhenNotFoundFile_Should_ReturnExecption()
        {
            // arrange
            var filePath = @"C:\projetos\teste\TestTransferBatch\File\";

            //action and assert
            Assert.ThrowsException<Exception>(() =>
            {
                var result = TransferFileReaderService.ReadTransferFile(filePath);
            });            
        }

        [TestMethod]
        public void ReadTransferFile_WhenInvalidContentFile_Should_ReturnExecption()
        {
            // arrange
            var filePath = @"C:\projetos\teste\TestTransferBatch\File\sample.transfersv2.csv";

            //action and assert
            Assert.ThrowsException<Exception>(() =>
            {
                var result = TransferFileReaderService.ReadTransferFile(filePath);
            });
        }
    }
}
