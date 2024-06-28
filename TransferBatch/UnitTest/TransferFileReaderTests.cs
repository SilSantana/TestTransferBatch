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
            var filePath = @"C:\Users\Asus\Desktop\teste\sample.transfers.csv";

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
            var filePath = @"C:\Users\Asus\Desktop\teste\";

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
            var filePath = @"C:\Users\Asus\Desktop\teste\sample.transfersv2.csv";

            //action and assert
            Assert.ThrowsException<Exception>(() =>
            {
                var result = TransferFileReaderService.ReadTransferFile(filePath);
            });
        }
    }
}
