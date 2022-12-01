namespace UniLibrary.Decorator
{
    public class PostGradDecorator : FeeDecorator
    {
        public override void CreateFee()
        {
            base.CreateFee();
            Fee = Fee*1.1;
        }     
    }
}