using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using umeAPI.Data;
using umeAPI.Models;
using umeAPI.Repo;

namespace umeAPI.Service
{
    public class chatsService 
    {
        ChatUmeDTBEntities2 data = new ChatUmeDTBEntities2();

        public void addInfoGroupChat(int idU, string idG)
        {
            SqlParameter iduser = new SqlParameter("@idU", idU);
            SqlParameter idgroup = new SqlParameter("@idG", idG);
            SqlParameter[] sqlParameter = new SqlParameter[] {iduser, idgroup};
            data.Database.ExecuteSqlCommand("insert into  InfoGroup (idUser,idGroup) values (@idU,@idG)", sqlParameter);
        }
        // tạo 1 nhóm chát
        public void createGroupchat(int idU,string idG)
        {
            SqlParameter iduser = new SqlParameter("@idU", idU);
            SqlParameter idgroup = new SqlParameter("@idG", idG);
            SqlParameter[] sqlParameter = new SqlParameter[] { iduser, idgroup };
            data.Database.ExecuteSqlCommand("insert into GroupChat (idUser,idGroup) values (@idU,@idG)", sqlParameter);
        }

        public void deteteMember(int idU, string idG)
        {
            throw new NotImplementedException();
        }

        public object loadGroupchat(int idUn, string idG)
        {
            throw new NotImplementedException();
        }

        public void Updatemember(string idG)
        {
            
        }

        public void updatelastMess(string LassMess,string idG)
        {
            SqlParameter lassMess = new SqlParameter("@lassMess", LassMess);
            SqlParameter idgroup = new SqlParameter("@idG", idG);
            SqlParameter[] sqlParameters = new SqlParameter[] { lassMess, idgroup };
            data.Database.ExecuteSqlCommand("update GroupChat set lastMessage= @lassMess where idGroup= @idG", sqlParameters);

        }

        //////////////////////////[tin nhan]/////////////////////////////////////
        //gui 1 tin nhan
        public void sendMess(int idU, string idG, string content, string idMess)
        {
            SqlParameter iduser = new SqlParameter("@idU",idU);
            SqlParameter idgroup = new SqlParameter("@idG", idG);
            SqlParameter ct = new SqlParameter("@content", content);
            SqlParameter idM = new SqlParameter("@idM", idMess);
            SqlParameter[] sqlParameters = new SqlParameter[] {iduser,ct ,idgroup, idM };
            data.Database.ExecuteSqlCommand("insert into groupChatMessage (idUser, content, idGroup,idMess) values (@idU,@content,@idG,@idM)", sqlParameters);
            
        }
        // laod all tn
        public object loadallMess( string idG)
        {

            SqlParameter idgroup = new SqlParameter("@idG", idG);
            var resuit = data.Database.SqlQuery<groupChatMessage>("select m.* from groupChatMessage m, InfoGroup i " +
                "where i.idGroup = m.idGroup " +
                "and m.idGroup = @idG " +
                "and m.idUser = i.idUser", idgroup);
            return resuit;
        }

        //load nhiieu group chat

        public object loadallox(int idU) {
            SqlParameter iduser = new SqlParameter("@idU", idU);
            var result = data.Database.SqlQuery<GroupChat>("select g.* from InfoGroup i, UserAccount u , GroupChat g " +
                "where u.idUser = I.idUser and u.idUser = @idU and g.idGroup = i.idGroup", iduser);
            return result;
        }
    }
}