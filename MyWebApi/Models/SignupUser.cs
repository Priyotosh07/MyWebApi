using System;
using System.Collections.Generic;

#nullable disable

namespace MyWebApi.Models
{
    public partial class SignupUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
