namespace UniLibrary.Decorator
{
    public class Fee : BaseFee
    {
        public override void CreateFee()
        {
            Fee = 3;
        }
    }
}