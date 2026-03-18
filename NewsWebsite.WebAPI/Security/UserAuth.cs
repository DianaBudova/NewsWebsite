namespace NewsWebsite.WebAPI.Security
{
    public class UserAuth
    {
        public bool Login(string username, string password)
        {
            return username == "admin" && password == "1234";
        }
    }
}
