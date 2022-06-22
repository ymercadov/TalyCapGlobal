using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalyCapGlobal
{
    public class Peticiones
    {
        public Api api { get; set; }
        public Jwt jwt { get; set; }
    }

    public class Api
    {
        public string UrlBase { get; set; }
        public string UrlBooks { get; set; }       
        public string UrlAuthors { get; set; }        
        public string UrlBooksAuthorsOne { get; set; }
        public string UrlUsers { get; set; }
    }

    public class Jwt
    {
        public string JWT_EXPIRE_MINUTES { get; set; }
        public string JWT_ISSUER_TOKEN { get; set; }
        public string JWT_AUDIENCE_TOKEN { get; set; }
        public string JWT_SECRET_KEY { get; set; }

    }
}
