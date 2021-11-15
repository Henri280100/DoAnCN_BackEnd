using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using umeAPI.Service;

namespace umeAPI.Controllers.API
{
    public class PosterController : ApiController
    {
        PosterService Pservice = new PosterService();


        // dang 1 poster
        [System.Web.Http.Route("api/Poster")]
        [System.Web.Http.HttpPost]
        public object Postposter(int idU, string content, string imgPoster)
        {
            try
            {
                var result = Pservice.addPoster(idU, content, imgPoster);
                if (result == 1)
                {
                    return Json(new { message = "success" });
                }
                else return Json(new { message = "failt" });
            }
            catch (Exception)
            {

                return Json(new { message = "failt" });
            }
        }

        //api load toan bo poster cua user
        [System.Web.Http.Route("api/Poster")]
        [System.Web.Http.HttpGet]
        public object GetLoadAllPoster(int idU)
        {
            try
            {
                var result = Pservice.loadAllPoster(idU);
                if (result == null)
                {
                    return Json(new { message = "null" });
                }
                else return Json(new
                {
                    message = "success",
                    Data = result
                });
            }
            catch (Exception)
            {
                return Json(new { message = "failt" });
            }
        }
    }
}
