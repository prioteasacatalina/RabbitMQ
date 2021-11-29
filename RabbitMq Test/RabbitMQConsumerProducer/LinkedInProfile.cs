using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMq_Test.RabbitMQConsumer
{
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
