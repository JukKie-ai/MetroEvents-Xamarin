using System;
using System.Collections.Generic;
using System.Text;

namespace MetroEvents.Tables {
    class RegisterUserTable {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
