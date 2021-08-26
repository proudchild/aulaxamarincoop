using System;
using System.Collections.Generic;
using System.Text;

namespace Multiplataforma.Models
{
    public class Lead
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public bool DoNotCall { get; set; }
        public bool DoNotEmail { get; set; }
        public LeadStatus Status { get; set; }

        public void Save()
        {

        }
    }
}
