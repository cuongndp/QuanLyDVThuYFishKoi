using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fish.Services.Interfaces;

namespace fish.Services.Services
{
    public class HomeService : IHomeService
    {
        public string GetApplicationDescription()
        {
            return "Your application description page.";
        }

        public string GetContactMessage()
        {
            return "Your contact page.";
        }
    }
}
