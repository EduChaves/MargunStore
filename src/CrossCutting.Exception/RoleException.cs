namespace MargunStore.CrossCutting.Exception
{
    public class RoleException : BaseException
    {
        public RoleException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
