﻿using WebApi.Utils;

namespace WebApi.Models
{
    public class RequestRegister
    {
       

        public string Email { get; set; }
        public string Fullname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }



    }
}
