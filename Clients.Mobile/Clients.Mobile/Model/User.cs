using System;
using System.Collections.Generic;
using System.Text;

namespace Clients.Mobile.Model
{
    public class User
    {
        private Guid Id { get; }
        private string FirstName { get; set; }
        private string Surname { get; set; }
        private int Age { get; set; }
        private DateTime CreationDate { get; set; }

    }
}
