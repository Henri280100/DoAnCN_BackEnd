//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace umeAPI.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAccount
    {
        public int idUser { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> createOn { get; set; }
        public Nullable<System.DateTime> updateOn { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isOnline { get; set; }
        public Nullable<bool> sex { get; set; }
        public Nullable<System.DateTime> birthDay { get; set; }
        public string email { get; set; }
        public string urlAvarta { get; set; }
        public string userName { get; set; }
        public Nullable<int> code { get; set; }
    }
}
