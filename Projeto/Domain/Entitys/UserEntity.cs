using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
   public class UserEntity
    {
        public bool? Success { get; set; }
        public string Error { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
