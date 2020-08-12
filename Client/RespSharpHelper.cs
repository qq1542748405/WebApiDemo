using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class RequestToken : RestRequest
    {
        public RequestToken(string username, string password)
        {
            Resource = "token";
            Method = Method.GET;
            AddParameter("grant_type", "password");
            AddParameter("UserName", username);
            AddParameter("Password", password);
        }
    }

    


}
