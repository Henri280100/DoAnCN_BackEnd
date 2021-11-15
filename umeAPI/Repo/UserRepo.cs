using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using umeAPI.Data;

namespace umeAPI.Repo
{
    public interface UserRepo
    {
        string InsertNewUser(UserAccount userAccount);
        object getUser(string phoneNumber,string passWord);
        bool onlineUser(string phoneNumber);
          Task<string> forgetPassword(string phoneNumber);
        object sendEmail(string email);
        object updateUser(string phoneNumer);
        string updateAvatar(int id, string url);
        bool IsExistPhoneNumner(string phoneNumber);
        bool IsExistEmail(string Email);
        object getUserByName(string name);
        object getUserByPhone(string phoneNumber);
       

    }
}