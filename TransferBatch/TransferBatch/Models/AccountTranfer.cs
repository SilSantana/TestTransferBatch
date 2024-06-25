namespace TransferBatch.Models
{
    public class AccountTranfer
    {
        public required string AccountId { get; set; }
        public required string TransferId { get; set; }
        public required decimal TotalTransferAmount { get; set; }  


        public override string ToString()
        {
            return $"Account_ID: {AccountId} | Transfer_ID: {TransferId} | Total_Transfer_Amount: {TotalTransferAmount}";
        }

    }
}
