namespace Academy.Test.Extensions
{
    using Academy.Models.Abstractions;

    public class ExtendedUser : User
    {
        public ExtendedUser(string username) : base(username)
        {
        }
    }
}
