using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using TransferBatch.Models;
using TransferBatch.Services;

namespace UnitTest
{
    [TestClass]
    public class TransferFileReaderServiceBenchmarkTests
    {
        private const string FilePath = @"C:\projetos\teste\TestTransferBatch\File\sample.transferCsv4.csv";

        [Benchmark]
        public List<AccountTranfer> BenchmarkReadTransferFile()
        {
            return TransferFileReaderService.ReadTransferFile(FilePath);
        }


        [TestMethod]
        public void BenchmarkReadTransferFile_Should_ReturnSuccesfully()
        {
            var summary = BenchmarkRunner.Run<TransferFileReaderServiceBenchmarkTests>();

        }

    }
}
