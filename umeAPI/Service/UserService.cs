using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using umeAPI.Repo;

namespace umeAPI.Data
{
    public class UserService : UserRepo
    {
        ChatUmeDTBEntities2 data = new ChatUmeDTBEntities2();

        public async Task<string> forgetPassword(string phoneNumber)
        {
            try
            {
                if (IsExistEmail(phoneNumber))
                {
                    SqlParameter phone = new SqlParameter("@phone", phoneNumber);
                    string userPass =  data.Database.SqlQuery<string>("select UserAccount.password from UserAccount where email = @phone",
                        phone).FirstOrDefault();
                    return userPass;
                }
                else return "Email chưa đăng ký";
            }
            catch (Exception)
            {
                return "failt";
            }
            

        }
        // =======================
        //hàm này để trả về người dùng khi người dùng truyền vào SĐT và mật khẩu{(đằn nhập bằng số điện thoại)
        //========================
        public object getUser(string phoneNumber, string passWord)
        {
                SqlParameter phone = new SqlParameter("@phone", phoneNumber);
                SqlParameter pass = new SqlParameter("@pass", passWord);

                SqlParameter[] sqlParameters = new SqlParameter[] { phone, pass };
                var usersinfo = data.UserAccounts.SqlQuery(" select * from UserAccount where phoneNumber = @phone and password =@pass", sqlParameters).FirstOrDefault();
                return usersinfo;
            
        }
        //hàm này để trả về người dùng khi người dùng truyền vào SĐT và mật khẩu{(đằn nhập bằng số điện thoại)
        //========================
        public object getUserByEmail(string Email, string password)
        {


            SqlParameter email = new SqlParameter("@phone", Email);
            SqlParameter pass = new SqlParameter("@pass", password);

            SqlParameter[] sqlParameters = new SqlParameter[] { email, pass };
            var usersinfo = data.UserAccounts.SqlQuery(" select * from UserAccount where email = @email and password =@pass", sqlParameters).FirstOrDefault();

            return usersinfo;
            
        }

        // =======================
        //hàm này để thêm tài khoản
        //========================
        public string InsertNewUser(UserAccount userAccount)
        {
            SqlParameter phoneNumber = new SqlParameter("@phoneNumber", userAccount.phoneNumber);
            SqlParameter createOn = new SqlParameter("@createOn", DateTime.Now);
            SqlParameter updateOn = new SqlParameter("@updateOn", DateTime.Now);
            SqlParameter sex = new SqlParameter("@sex", userAccount.sex);
            SqlParameter password = new SqlParameter("@password", userAccount.password);
            SqlParameter email = new SqlParameter("@email", userAccount.email);
            SqlParameter userName = new SqlParameter("@userName", userAccount.userName);

            SqlParameter[] sqlParameters = new SqlParameter[] { phoneNumber, createOn, updateOn, sex, password, email, userName };
            if (!IsExistEmail(userAccount.email))
            {
                if (!IsExistPhoneNumner(userAccount.phoneNumber))
                {
                    int isInsert = data.Database.
                        ExecuteSqlCommand
                        ("insert into UserAccount (phoneNumber,createOn,updateOn,sex,password,email,userName) values ( @phoneNumber,@createOn,@updateOn,@sex,@password,@email,@userName)", sqlParameters);
                    if (isInsert == 1)// tạo thành công
                        return "success";
                    else return "Tạo tài khoản thất bại";
                }
                else
                {
                    return "số điện thoại đã có người đăng ký";
                }
            }
            else return "Email đã có người đăng ký";
        }
        // tìm người dùng qua số điện thoại
        public UserAccount SerchUserByPhoneNumber(string phoneNumber)
        {
            SqlParameter phone = new SqlParameter("@phone", phoneNumber);
            var usersinfo = data.UserAccounts.SqlQuery(" select * from UserAccount where phoneNumber = @phone", phone).FirstOrDefault();
            return usersinfo;
            
        }
        public UserAccount SerchUserByIdUer(int id)
        {
            SqlParameter phone = new SqlParameter("@id", id);
            var usersinfo = data.UserAccounts.SqlQuery(" select * from UserAccount where idUser = @id", phone).FirstOrDefault();
            return usersinfo;
        }
        public bool onlineUser(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public object sendEmail(string email)
        {
            throw new NotImplementedException();
        }

        public object updateUser(string phoneNumer)
        {
            throw new NotImplementedException();
        }

        

        public string updateAvatar(int id, string url)
        {
            SqlParameter iduser = new SqlParameter("@iduser", id);
            SqlParameter urlAvarta = new SqlParameter("@urlAvarta", url);
            SqlParameter[] user = new SqlParameter[] {urlAvarta,iduser};
            int result = data.Database.ExecuteSqlCommand("update UserAccount set urlAvarta=@urlAvarta where idUser=@iduser", user);
            if (result == 1)
            {
                return "success";
            }
            else return "failt";
        }

        public string updateCode(int id, int code)
        {
            SqlParameter iduser = new SqlParameter("@iduser", id);
            SqlParameter urlAvarta = new SqlParameter("@urlAvarta", code);
            SqlParameter[] user = new SqlParameter[] { urlAvarta, iduser };
            int result = data.Database.ExecuteSqlCommand("update UserAccount set urlAvarta=@urlAvarta where idUser=@iduser", user);
            if (result == 1)
            {
                return "success";
            }
            else return "failt";
        }

        public bool IsExistPhoneNumner(string phoneNumber)
        {
            SqlParameter phone = new SqlParameter("@phone", phoneNumber);
            var userPhone = data.UserAccounts.SqlQuery("select * from UserAccount where phoneNumber = @phone", phone).FirstOrDefault();
            if (userPhone == null)
            {
                return false;
            }
            else return true;
        }

        public bool IsExistEmail(string Email)
        {
            SqlParameter email = new SqlParameter("@email", Email);
            var userPhone = data.UserAccounts.SqlQuery("select * from UserAccount where email = @email", email).FirstOrDefault();
            if (userPhone == null)
            {
                return false;
            }
            else return true;
        }

        public object getUserByName(string Name)
        {
            SqlParameter name = new SqlParameter("@name", Name);
            var usersinfo = data.UserAccounts.SqlQuery(" select * from UserAccount where phoneNumber= @name", name).FirstOrDefault();
            return usersinfo;
        }

        public object getUserByPhone(string phoneNumber)
        {
            SqlParameter phone = new SqlParameter("@phone", phoneNumber);
            var usersinfo = data.UserAccounts.SqlQuery(" select * from UserAccount where phoneNumber= @phone", phone).FirstOrDefault();
            return usersinfo;
        }

    }
}