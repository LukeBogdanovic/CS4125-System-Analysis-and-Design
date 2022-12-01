namespace UniLibrary.Decorator
{
    public abstract class BaseFee
    {
        public double Fee { get; set; }
        public abstract void CreateFee();

    }
}
