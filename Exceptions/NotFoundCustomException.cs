namespace StudentManagementAPI.Exceptions
{
    public class NotFoundCustomException:Exception
    {

        public NotFoundCustomException()
        {

        }

        public NotFoundCustomException(string msg) : base(msg)
        {

        }
    }
}
