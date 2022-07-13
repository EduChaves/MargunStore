namespace MargunStore.CrossCutting.Exception
{
    public class BaseException: System.Exception
    {
        public BaseException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
