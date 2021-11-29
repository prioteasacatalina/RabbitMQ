using System;

namespace Model
{
    public class Order
    {
        public string LinkedInLink { get; set; }
    }

    public class LinkedInProfile
    {
        public string FullName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public LinkedInProfile()
        {
            this.FullName = "Prioteasa Catalina-Eleonora";
            this.City = "Bucharest";
            this.Email = "prioteasa_catalina@yahoo.com";
            this.Age = 22;
        }
    }
}

