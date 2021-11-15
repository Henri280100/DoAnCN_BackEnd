using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using umeAPI.Service;

namespace umeAPI.Controllers.API
{
    public class FriendsController : ApiController
    {
        friendsService Fservice = new friendsService();

        //kiểm tra có phải bạn bè ko
        [System.Web.Mvc.Route("api/Friends/isFriends")]
        [System.Web.Mvc.HttpGet]
        public string GetisFriends(int idU, int idF)
        {
            try
            {
               return Fservice.isAdd(idU, idF);

            }
            catch (Exception)
            {
                return "false";
            }

        }
    }
}
