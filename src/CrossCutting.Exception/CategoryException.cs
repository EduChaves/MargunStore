namespace MargunStore.CrossCutting.Exception
{
    public class CategoryException : BaseException
    {
        public CategoryException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
