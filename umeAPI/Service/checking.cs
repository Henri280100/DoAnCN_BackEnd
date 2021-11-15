using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace umeAPI.Service
{
    public class checking
    {
        public bool checkPhone(string phoneNumber)
        {
            char[] phone = phoneNumber.ToCharArray();
            if (!(phone.Length <= 10 && phone.Length > 9))
                return false;
            for (int i = 0; i < phone.Length; i++)
            {
                if (Regex.IsMatch(phone[i].ToString(), @"^[a-zA-Z]+$"))
                {
                    return false;
                }
                else return true;
            }
            return false;
        }
        public bool checkPass(string pass)
        {
            if (pass.Length < 6)
            {
                return false;
            }
            else return true;
        }
        private readonly Random _random = new Random();
        public  int RandomNumber()
        {
            return _random.Next(100000, 999999);
        }
        public bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
    }
}