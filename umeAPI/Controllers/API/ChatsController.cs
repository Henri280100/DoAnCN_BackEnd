using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using umeAPI.Data;
using umeAPI.Service;

namespace umeAPI.Controllers.API
{
    public class ChatsController : ApiController
    {
        chatsService cService = new chatsService();

        public void PostGroupchat(int idUCreate, int idU2)
        {
            Guid id = Guid.NewGuid();
            string idGroup = id.ToString();
            try
            {
                cService.createGroupchat(idUCreate, idGroup);
                cService.addInfoGroupChat(idUCreate, idGroup);
                cService.addInfoGroupChat(idU2, idGroup);
            }
            catch (Exception)
            {
            }
        }

        //api gui tin nhan
        [System.Web.Http.Route("api/Chats")]
        [System.Web.Http.HttpPost]
        public object PostSendMessage(int idSender, string idGroup, string conetnt)
        {
            string idM = "";
            try
            {
                Guid id = Guid.NewGuid();
                idM = id.ToString();
                cService.sendMess(idSender, idGroup, conetnt, idM);
                cService.updatelastMess(conetnt, idGroup);
                return idM;
            }
            catch (Exception)
            {
                return idM;
            }
        }

        //api Load toan bo tin nhan cua 1 group chat
        [System.Web.Http.Route("api/Chats")]
        [System.Web.Http.HttpPost]
        public object PostloadAllmess(string idG)
        {
            try
            {
                var resuit= cService.loadallMess(idG);
                return Json(new
                {
                    message = "success",
                    Data = resuit
                });
            }
            catch (Exception)
            {

                return Json(new
                {
                    message = "failt"
                });
            }
        }
        //api Load toan bo groupchat cua 1 group chat
        [System.Web.Http.Route("api/Chats")]
        [System.Web.Http.HttpGet]
        public object GetAllBocChat(int idU)
        {
            try
            {
                var result = cService.loadallox(idU);
                if (result == null)
                {
                    return Json(new {message="null" });
                }
                else return Json(new { message = "seccess",
                                        Data = result});
            }
            catch (Exception)
            {
                return Json(new { message = "failt" });
            }
        }

        //api get tin nhan bang id

    }
}
