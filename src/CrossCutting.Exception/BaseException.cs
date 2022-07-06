namespace MargunStore.CrossCutting.Exception
{
    public class BaseException: System.Exception
    {
        public BaseException() { }

        public BaseException(string message) { }

        public BaseException(string message, System.Exception ex) { }
    }
}
