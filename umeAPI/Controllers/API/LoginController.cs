using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using umeAPI.Data;
using umeAPI.Service;

namespace umeAPI.Controllers.API
{
    public class LoginController : ApiController

    {

        UserService Uservice = new UserService();
        checking checking = new checking();

        // GET: api/Login
        // API khi đăng nhập bằng số điện thoại
        [System.Web.Mvc.Route("api/Login/getuser")]
        [System.Web.Mvc.HttpGet]
        public object GetUser(string phoneNumber, string password)
        {
            if (checking.checkPhone(phoneNumber))
            {
                if (Uservice.IsExistPhoneNumner(phoneNumber))
                {
                    var c = Uservice.getUser(phoneNumber, password);
                    if (c != null)
                    {
                        return Json(new
                        {
                            message = "success",
                            data = c
                        });
                    }
                    else return Json(new
                    {
                        message = "sai mật khẩu",
                        data = c
                    });
                }
                else
                    return Json(new
                    {
                        message = "tài khoản không tồn tại"
                    });
            }
            else return Json(new
            {
                message = "số điện thoại sai định dạng" });
        }


        // API khi đăng nhập bằng Email
        [System.Web.Mvc.Route("api/Login/getuserByEmail")]
        [System.Web.Mvc.HttpGet]
        public object GetUserbyEmail(string email, string password)
        {
            if (checking.isEmail(email))
            {
                if (Uservice.IsExistEmail(email))
                {
                    var c = Uservice.getUserByEmail(email, password);
                    if (c != null)
                    {
                        return Json(new
                        {
                            message = "success",
                            data = c
                        });
                    }
                    else return Json(new
                    {
                        message = "sai mật khẩu"
                    });
                }
                else return Json(new
                {
                    message = "Enail đã tồn tại"
                });

            }
            else return Json(new
            {
                message = "số điện thoại sai định dạng"
            });
        }


        // api đăng ký số điện thoại
        [System.Web.Mvc.Route("api/Login/register")]
        [System.Web.Mvc.HttpPost]
        public object PostRegister(UserAccount userAccount)
        {
            if (userAccount.sex == null || userAccount.phoneNumber == null || userAccount.password == null || userAccount.email == null || userAccount.userName == null)
                return "bạn chưa nhập đủ thông tin cần thiết";
            if (checking.checkPhone(userAccount.phoneNumber) && checking.checkPass(userAccount.password))
            {
                var result = Uservice.InsertNewUser(userAccount);
                return Json(new
                {
                    message = result
                });
            }
            else
            {
                return Json(new {
                    message = "số điện thoại sai định dạng"
                });
            }
        }


        //api quên mật khẩu
        [System.Web.Mvc.Route("api/Login/forgetpassword")]
        [System.Web.Mvc.HttpPost]
        public async Task<string> PostForgetPassword(string email)
        {
            string pass = await Uservice.forgetPassword(email) as string;
            if (pass != null && pass != "failt")
            {
                if (pass != "Email chưa đăng ký")
                {
                    await Authentication.sendPassByEmail(email, "App chat Ume Gửi Mật khâu ", " Bạn thật vô dụng! Có cái mật khẩu thôi cũng quên. làm tao phải viết hàm" +
                  "lấy lại mk cho bạn: mk mới chủa bạn là:" + pass);
                    return "success";
                }
                else return "Email chưa đăng ký";
            }
            else return pass;  
        }


      
    }
}
