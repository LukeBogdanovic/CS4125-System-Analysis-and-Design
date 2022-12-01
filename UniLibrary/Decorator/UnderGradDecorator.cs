namespace UniLibrary.Decorator
{
    public class UnderGradDecorator : FeeDecorator
    {
        public override void CreateFee()
        {
            base.CreateFee();
            Fee = Fee * 1.25;
        }
    }
}