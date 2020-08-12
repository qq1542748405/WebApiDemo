using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class UserClient
    {
        private static UserClient client = new UserClient();

        private string tokenType;

        private string accessToken;

        private UserClient()
        {

        }

        public static UserClient Client
        {
            get => client;
        }

        public string TokenType { get => tokenType; }

        public string AccessToken { get => accessToken; }

        public void Login(string tokenType, string accessToken)
        {
            this.tokenType = tokenType;
            this.accessToken = accessToken;
        }


    }
}
