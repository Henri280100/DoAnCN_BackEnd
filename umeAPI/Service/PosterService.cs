using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using umeAPI.Data;

namespace umeAPI.Service
{
    public class PosterService
    {
        ChatUmeDTBEntities2 data = new ChatUmeDTBEntities2();

        public int addPoster(int idU, string content , string imgPoster)
        {
            SqlParameter iduser = new SqlParameter("@idU", idU);
            SqlParameter ct = new SqlParameter("@ct", content);
            SqlParameter img = new SqlParameter("@img", imgPoster);
            SqlParameter[] sqlParameters = new SqlParameter[] { iduser, ct, img };

            int result= data.Database.ExecuteSqlCommand("insert into Poster(content,idUser, imgPoster) values (@ct,@idU,@img)", sqlParameters);
            return result; 

        }

        public object loadAllPoster(int idU)
        {
            SqlParameter iduser = new SqlParameter("@idU", idU);
            var resuit = data.Database.SqlQuery<Poster>("select * from Poster where idUser = @idU",iduser);
            return resuit;
        }
    }
}