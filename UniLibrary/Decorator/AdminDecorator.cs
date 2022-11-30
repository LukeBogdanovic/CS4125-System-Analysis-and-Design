namespace UniLibrary.Decorator
{
    public class AdminDecorator : FeeDecorator
    {
        public override void CreateFee()
        {
            base.CreateFee();
            Fee = Fee*0.5;
        }     
    }
}