

namespace Managers.Interface
{
    using Models;
    public interface IUserManager
    {
        //Interface that implements 
        public bool Register(RegisterModel userData);
        public bool Login(string email, string password);
        public bool ForgetPassword(string Email);
    }
}
