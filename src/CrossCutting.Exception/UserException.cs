namespace MargunStore.CrossCutting.Exception
{
    public class UserException : BaseException
    {
        public UserException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
