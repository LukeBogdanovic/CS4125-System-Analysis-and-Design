namespace UniLibrary.Decorator
{
    public class FeeDecorator : BaseFee
    {
        BaseFee? BaseFee;
        public void AttachTo(BaseFee Fee)
        {
            this.BaseFee = Fee;
            this.Fee = Fee.Fee;
        }
        public override void CreateFee()
        {
            BaseFee!.CreateFee();
        }
    }
}