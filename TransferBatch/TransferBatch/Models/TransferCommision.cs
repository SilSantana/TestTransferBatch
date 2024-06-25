namespace TransferBatch.Models
{
    public class TransferCommision
    {
        public required string AccountId { get; set; }
        public required decimal TotalCommision { get; set; }


        public override string ToString()
        {
            return $"Account_ID: {AccountId} | Total_Commision: {TotalCommision}";
        }

    }
}
