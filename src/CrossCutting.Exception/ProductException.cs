namespace MargunStore.CrossCutting.Exception
{
    public class ProductException : BaseException
    {
        public ProductException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
