using System;
using System.Collections.Generic;
using System.Text;

namespace Clients.Mobile.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
