using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umeAPI.Data;

namespace umeAPI.Repo
{
    public interface friendsRepo
    {
        object showlistfriends(int idUser);
        object addnewFriend(int idUser, int idFriend);
        bool deteteFriend(int idUser);
        object showlistchatfriends(int idf);
        object updatefriends(int idUser,string nickname);
        string isAdd(int idUser, int idFriend);

    }
}