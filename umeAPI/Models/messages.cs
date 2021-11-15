using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace umeAPI.Models
{
    public class messages
    {
        public string idMess { get; set; }
        public int idUser { get; set; }
        public string idGroup { get; set; }
        public DateTime createOn { get; set; }
        public string content { get; set; }
        public string userName { get; set; }
        public string urlAvarta { get; set; }
    }
}