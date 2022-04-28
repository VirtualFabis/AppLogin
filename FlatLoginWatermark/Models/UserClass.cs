using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatLoginWatermark.Models
{
    internal class UserClass
    {
        public string User { get; set; }
        public string Password { get; set; }
        public Boolean close { get; set; }

    }
    public class SendData
    {
        public string User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool send { get; set; }

    }
}
