using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using umeAPI.Data;
using umeAPI.Repo;

namespace umeAPI.Service
{
    public class friendsService : friendsRepo
    {
        ChatUmeDTBEntities2 data = new ChatUmeDTBEntities2();
        UserService service= new UserService();

        public object addnewFriend(int idUser, int idFriend)
        {
            SqlParameter iduser =  new SqlParameter( "@idU",idUser);
            SqlParameter idf = new SqlParameter("@idf", idFriend);
            
            SqlParameter[] sqlParameters = new SqlParameter[] { iduser, idf };
            SqlParameter[] sqlParameters2 = new SqlParameter[] { idf, iduser };
            try
            {
                int add = data.Database.ExecuteSqlCommand
                            ("insert into Friends(idUser,idFriend) values (@idU,@idf)", sqlParameters);
                int add2 = data.Database.ExecuteSqlCommand
                            ("insert into Friends(idUser,idFriend) values (@idf,@idU)", sqlParameters2);
                if (add == 1)// nếu đã thêm thành công thì xuất ra người dùng mới add
                {
                    var account = service.SerchUserByIdUer(idFriend);
                    if (account != null)
                        return account;
                }
                else return null;
            }
            catch (Exception)
            {
                return null;

            }
            return null;
        }

        public bool deteteFriend(int idUser)
        {
            throw new NotImplementedException();
        }

        public string isAdd(int idUser, int idFriend)
        {
            SqlParameter iduser = new SqlParameter("@idU", idUser);
            SqlParameter idf = new SqlParameter("@idf", idFriend);
            SqlParameter[] sqlParameters = new SqlParameter[] { iduser, idf };

            try
            {
                var resuit = data.Friends.SqlQuery("select * from Friends where idUser= @idU and idFriend= @idf", sqlParameters).FirstOrDefault();
                if (resuit != null)
                    return "true";
                else return "false";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        public object showlistchatfriends(int idf)
        {
            SqlParameter id = new SqlParameter("@id", idf);
            var result = data.UserAccounts.SqlQuery("select c.* from UserAccount c, Friends f where c.idUser = f.idFriend and f.idUser=@id and f.isActive=0", id).ToList<UserAccount>();

            return result;
        }

        public object showlistfriends(int idUser)
        {      
            SqlParameter id = new SqlParameter("@id", idUser);
            var result = data.UserAccounts.SqlQuery("select c.* from UserAccount c, Friends f where c.idUser = f.idFriend and f.idUser=@id", id).ToList<UserAccount>();

            return result;
        }

        public object updatefriends(int idUser, string nickname)
        {
            throw new NotImplementedException();
        }
    }
}