using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.DTOs.Request
{
    public class UserRequest
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
    }
}
